using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
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
		private readonly IMapper _mapper;
		private readonly IToastNotification _toast;
		private readonly IValidator<AppUser> _validator;
		private readonly IAppUserManager _appUserManager;

		public UserController(IMapper mapper, IToastNotification toast, IValidator<AppUser> validator,IAppUserManager appUserManager)
		{
			_mapper = mapper;
			_toast = toast;
			_validator = validator;
			_appUserManager = appUserManager;
		}
		public async Task<IActionResult> Index()
		{
			var result = await _appUserManager.GetAllUsersWithRoleAsync();
			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var roles = await _appUserManager.GetAllRolesAsync();
			return View(new UserAddDto { Roles = roles });
		}

		[HttpPost]
		public async Task<IActionResult> Add(UserAddDto userAddDto)
		{
			var map = _mapper.Map<AppUser>(userAddDto);
			var validation = await _validator.ValidateAsync(map);
			var roles = await _appUserManager.GetAllRolesAsync();

			if (ModelState.IsValid)
			{
				var result = await _appUserManager.CreateUserAsync(userAddDto);
				if (result.Succeeded)
				{
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
			var userToUpdate = await _appUserManager.FindAsync(userId);

			var roles = await _appUserManager.GetAllRolesAsync();

			var map = _mapper.Map<UserUpdateDto>(userToUpdate);
			map.Roles = roles;
			return View(map);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var userToUpdate = await _appUserManager.FindAsync(userUpdateDto.Id);

			if (userToUpdate != null)
			{
				var roles = await _appUserManager.GetAllRolesAsync();
				if (ModelState.IsValid)
				{
					var map = _mapper.Map(userUpdateDto, userToUpdate);
					var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
						var result = await _appUserManager.UpdateUserAsync(userUpdateDto);
						if (result.Succeeded)
						{
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
			var result = await _appUserManager.DeleteUserAsync(userId);
			if (result.identityResult.Succeeded)
			{
				_toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "İşlem Başarılı" });
				return RedirectToAction("Index", "User", new { Area = "Admin" });
			}
			else
			{
				result.identityResult.AddToIdentityModelState(this.ModelState);
			}
			return NotFound();
		}

		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var profile = await _appUserManager.GetUserProfileAsync();
			return View(profile);
		}

		[HttpPost]
		public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
		{
			if (ModelState.IsValid)
            {
				var result = await _appUserManager.UserProfileUpdateAsync(userProfileDto);
                if (result.isTrue && result.identityResult.Succeeded && result.validationResult.IsValid)
                {
					_toast.AddSuccessToastMessage("Profil Güncellendi.", new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "Home", new { Area = "Admin" });
				}
				else
				{
					_toast.AddErrorToastMessage("Bir Hata Oluştu.", new ToastrOptions { Title = "İşlem Başarısız" });
                    if (result.identityResult != null)
                    {
						result.identityResult.AddToIdentityModelState(this.ModelState);
					}
					else if(!result.validationResult.IsValid)
					{
						result.validationResult.AddToModelState(this.ModelState);
					}
                    return View();
				}
            }
            return NotFound();
		}
	}
}
