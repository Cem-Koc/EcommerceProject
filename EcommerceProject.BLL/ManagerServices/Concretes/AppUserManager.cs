using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
	public class AppUserManager : IAppUserManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAppUserRepository _userRepository;
		private readonly IMapper _mapper;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ClaimsPrincipal _user;
		private readonly IValidator<AppUser> _validator;
		public AppUserManager(IUnitOfWork unitOfWork, IAppUserRepository userRepository, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IHttpContextAccessor httpContextAccessor, SignInManager<AppUser> signInManager, IValidator<AppUser> validator)
		{
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = roleManager;
			_httpContextAccessor = httpContextAccessor;
			_signInManager = signInManager;
			_user = _httpContextAccessor.HttpContext.User;
			_validator = validator;
		}

        public async Task<IdentityResult> RegisterUserAsync(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            map.CreatedBy = userAddDto.Email;
            map.CreatedDate = DateTime.Now;
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
            if (result.Succeeded)
            {
                var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, findRole.ToString());
                return result;
            }
            else
            {
                return result;
            }
        }
        public async Task<bool> CreateUserAsync(AppUser item)
		{
			var result = await _userRepository.AddUser(item);
			await _unitOfWork.SaveAsync();
			return result;
		}

		public async Task<List<UserListDto>> GetAllUsersWithRoleAsync()
		{
			var users = await _userManager.Users.ToListAsync();
			var map = _mapper.Map<List<UserListDto>>(users);

			foreach (var item in map)
			{
				var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
				var role = string.Join("", await _userManager.GetRolesAsync(findUser));

				item.Role = role;
			}
			return map;
		}

		public async Task<List<AppRole>> GetAllRolesAsync()
		{
			return await _roleManager.Roles.ToListAsync();
		}

		public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
		{
			var map = _mapper.Map<AppUser>(userAddDto);
			map.UserName = userAddDto.Email;
			map.CreatedBy = _user.GetLoggedInUserEmail();
			map.CreatedDate = DateTime.Now;
			var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
			if (result.Succeeded)
			{
				var findRole = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
				await _userManager.AddToRoleAsync(map, findRole.ToString());
				return result;
			}
			else
			{
				return result;
			}
		}

		public async Task<string> GetUserRoleAsync(AppUser appUser)
		{
			return string.Join("", await _userManager.GetRolesAsync(appUser));
		}

		public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
		{
			var userToUpdate = await FindAsync(userUpdateDto.Id);
			var userRole = await GetUserRoleAsync(userToUpdate);
			userToUpdate.ModifiedBy = _user.GetLoggedInUserEmail();
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
				return result;
			}
			else
			{
				return result;
			}
		}

		public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(int userId)
		{
			var userToDelete = await FindAsync(userId);
			var result = await _userManager.DeleteAsync(userToDelete);
            if (result.Succeeded)
            {
				return (result, userToDelete.Email);
			}
			else
			{
				return(result, null);
			}
        }

		public async Task<UserProfileDto> GetUserProfileAsync()
		{
			var userId = _user.GetLoggedInUserId();
			var user = await FindAsync(userId);
			var map = _mapper.Map<UserProfileDto>(user);
			return map;
		}

		public async Task<(bool isTrue, IdentityResult? identityResult, ValidationResult? validationResult)> UserProfileUpdateAsync(UserProfileDto userProfileDto)
		{
			var userId = _user.GetLoggedInUserId();
			var user = await FindAsync(userId);

			var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
			if (isVerified && userProfileDto.NewPassword != null)
			{
				var result = await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
				if (result.Succeeded)
				{
					await _userManager.UpdateSecurityStampAsync(user);
					await _signInManager.SignOutAsync();
					await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

					user.FirstName = userProfileDto.FirstName;
					user.LastName = userProfileDto.LastName;
					user.PhoneNumber = userProfileDto.PhoneNumber;
					user.Email = userProfileDto.Email;
					user.UserName = userProfileDto.Email;
					user.ModifiedBy = user.Email;
					user.ModifiedDate = DateTime.Now;
					user.Status = ENTITIES.Enums.DataStatus.Updated;

					var validation = await _validator.ValidateAsync(user);
					if (validation.IsValid)
					{
						var saveResult = await _userManager.UpdateAsync(user);
						return (true, saveResult, validation);
					}
					else
					{
						return (false, null, validation);
					}
				}
				else
				{
					return (false,null,null);
				}
			}
			else if (isVerified)
			{
				await _userManager.UpdateSecurityStampAsync(user);
				user.FirstName = userProfileDto.FirstName;
				user.LastName = userProfileDto.LastName;
				user.PhoneNumber = userProfileDto.PhoneNumber;
				user.Email = userProfileDto.Email;
				user.UserName = userProfileDto.Email;
				user.ModifiedBy = user.Email;
				user.ModifiedDate = DateTime.Now;
				user.Status = ENTITIES.Enums.DataStatus.Updated;

				var validation = await _validator.ValidateAsync(user);
                if (validation.IsValid)
                {
					var saveResult = await _userManager.UpdateAsync(user);
					return (true, saveResult, validation);
				}
				else
				{
					return (false, null, validation);
				}
			}
			else
			{
				return (false, null,null);
			}
		}
		public void Add(AppUser item)
		{
			_unitOfWork.GetRepository<AppUser>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(AppUser item)
		{
			await _unitOfWork.GetRepository<AppUser>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<AppUser> list)
		{
			_unitOfWork.GetRepository<AppUser>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<AppUser> list)
		{
			await _unitOfWork.GetRepository<AppUser>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<AppUser, bool>> exp)
		{
			return await _unitOfWork.GetRepository<AppUser>().AnyAsync(exp);
		}

		public void Delete(AppUser item)
		{
			_unitOfWork.GetRepository<AppUser>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<AppUser> list)
		{
			_unitOfWork.GetRepository<AppUser>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(AppUser item)
		{
			_unitOfWork.GetRepository<AppUser>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<AppUser> list)
		{
			_unitOfWork.GetRepository<AppUser>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<AppUser> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<AppUser>().FindAsync(id);
		}

		public async Task<AppUser> FirstOrDefaultAsync(Expression<Func<AppUser, bool>> exp)
		{
			return await _unitOfWork.GetRepository<AppUser>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<AppUser> GetActives()
		{
			return _unitOfWork.GetRepository<AppUser>().GetActives();
		}

		public IQueryable<AppUser> GetAll()
		{
			return _unitOfWork.GetRepository<AppUser>().GetAll();
		}

		public IQueryable<AppUser> GetModifieds()
		{
			return _unitOfWork.GetRepository<AppUser>().GetModifieds();
		}

		public IQueryable<AppUser> GetPassives()
		{
			return _unitOfWork.GetRepository<AppUser>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<AppUser, X>> exp)
		{
			return _unitOfWork.GetRepository<AppUser>().Select(exp);
		}

		public async Task Update(AppUser item)
		{
			await _unitOfWork.GetRepository<AppUser>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<AppUser> list)
		{
			await _unitOfWork.GetRepository<AppUser>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<AppUser> Where(Expression<Func<AppUser, bool>> exp)
		{
			return _unitOfWork.GetRepository<AppUser>().Where(exp);
		}

	}
}
