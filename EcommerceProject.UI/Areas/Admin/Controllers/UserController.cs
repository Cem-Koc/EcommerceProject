using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.Areas.Admin.Consts;
using EcommerceProject.UI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;
using System.Security.Claims;
using static EcommerceProject.UI.ResultMessages.Messages;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toast;
		IHttpContextAccessor _httpContextAccessor;
		private readonly IValidator<AppUser> _validator;
		private readonly ClaimsPrincipal _user;

		public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification toast, IHttpContextAccessor httpContextAccessor, IValidator<AppUser> validator)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_mapper = mapper;
			_toast = toast;
			_httpContextAccessor = httpContextAccessor;
			_validator = validator;
			_user = _httpContextAccessor.HttpContext.User;
		}
		public async Task<IActionResult> Index()
		{
			var users = await _userManager.Users.ToListAsync();
			var map = _mapper.Map<List<UserListDto>>(users);

			foreach (var item in map)
			{
				var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
				var role = string.Join("", await _userManager.GetRolesAsync(findUser));

				item.Role = role;
			}
			return View(map);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return View(new UserAddDto { Roles = roles });
		}

		[HttpPost]
		public async Task<IActionResult> Add(UserAddDto userAddDto)
		{
			var map = _mapper.Map<AppUser>(userAddDto);
			var validation = await _validator.ValidateAsync(map);
			var roles = await _roleManager.Roles.ToListAsync();
			var user = _user.GetLoggedInUserEmail();

			if (ModelState.IsValid)
			{
				map.UserName = userAddDto.Email;
				map.CreatedBy = user;
				map.CreatedDate = DateTime.Now;
				var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
				if (result.Succeeded)
				{
					var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
					await _userManager.AddToRoleAsync(map, findRole.ToString());
					_toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "User", new { Area = "Admin" });
				}
				else
				{
					result.AddToIdentityModelState(this.ModelState);
					validation.AddToModelState(this.ModelState);
					return View(new UserAddDto { Roles = roles });
				}
			}
			return View(new UserAddDto { Roles = roles });
		}

		[HttpGet]
		public async Task<IActionResult> Update(int userId)
		{
			var userToUpdate = await _userManager.FindByIdAsync(userId.ToString());

			var roles = await _roleManager.Roles.ToListAsync();

			var map = _mapper.Map<UserUpdateDto>(userToUpdate);
			map.Roles = roles;
			return View(map);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var userToUpdate = await _userManager.FindByIdAsync(userUpdateDto.Id.ToString());
			var user = _user.GetLoggedInUserEmail();

			if (userToUpdate != null)
			{
				var userRole = string.Join("", await _userManager.GetRolesAsync(userToUpdate));
				var roles = await _roleManager.Roles.ToListAsync();
				if (ModelState.IsValid)
				{
					var map = _mapper.Map(userUpdateDto, userToUpdate);
					var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
						userToUpdate.ModifiedBy = user;
						userToUpdate.ModifiedDate = DateTime.Now;
						userToUpdate.Status = ENTITIES.Enums.DataStatus.Updated;
						userToUpdate.UserName = userUpdateDto.Email;
						userToUpdate.SecurityStamp = Guid.NewGuid().ToString();
						var result = await _userManager.UpdateAsync(userToUpdate);
						if (result.Succeeded)
						{
							await _userManager.RemoveFromRoleAsync(userToUpdate, userRole);
							var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
							await _userManager.AddToRoleAsync(userToUpdate, findRole.Name);
							_toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
							return RedirectToAction("Index", "User", new { Area = "Admin" });
						}
						else
						{
							result.AddToIdentityModelState(this.ModelState);
							return View(new UserUpdateDto { Roles = roles });
						}
					}
					else
					{
						validation.AddToModelState(this.ModelState);
						return View(new UserUpdateDto { Roles = roles });
					}
                    
				}
			}
			return NotFound();
		}

		public async Task<IActionResult> Delete(int userId)
		{
			var userToDelete = await _userManager.FindByIdAsync(userId.ToString());

			var result = await _userManager.DeleteAsync(userToDelete);
			if (result.Succeeded)
			{
				_toast.AddSuccessToastMessage(Messages.User.Delete(userToDelete.Email), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "User", new { Area = "Admin" });
			}
			else
			{
				result.AddToIdentityModelState(this.ModelState);
			}
			return NotFound();
		}
	}
}
