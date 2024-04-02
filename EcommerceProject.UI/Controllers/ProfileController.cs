using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EcommerceProject.UI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly IValidator<AppUser> _validator;
        private readonly IAppUserManager _appUserManager;
        public ProfileController(IMapper mapper, IToastNotification toast, IValidator<AppUser> validator, IAppUserManager appUserManager)
        {
            _mapper = mapper;
            _toast = toast;
            _validator = validator;
            _appUserManager = appUserManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
			var profile = await _appUserManager.GetUserProfileAsync();
			return View(profile);
		}

		[HttpPost]
		public async Task<IActionResult> Index(UserProfileDto myProfileUpdateDto)
		{
			//var userToUpdate = await _appUserManager.FindAsync(myProfileUpdateDto.Id);

			//if (userToUpdate != null)
			//{
			//	if (ModelState.IsValid)
			//	{
			//		var map = _mapper.Map(myProfileUpdateDto, userToUpdate);
			//		var validation = await _validator.ValidateAsync(map);

			//		if (validation.IsValid)
			//		{
			//			var result = await _appUserManager.MyProfileUpdate(myProfileUpdateDto);
			//			if (result.Succeeded)
			//			{
			//				_toast.AddSuccessToastMessage("Profiliniz güncellenmiştir.", new ToastrOptions { Title = "İşlem Başarılı" });
			//				return View();
			//			}
			//			else
			//			{
			//				_toast.AddErrorToastMessage("Bir hata oluştu.", new ToastrOptions { Title = "İşlem Başarısız" });
			//				return View();
			//			}
			//		}
			//		else
			//		{
			//			_toast.AddErrorToastMessage("Bir hata oluştu.", new ToastrOptions { Title = "İşlem Başarısız" });
			//			return View();
			//		}
			//	}
			//}
			//return View();

			if (ModelState.IsValid)
			{
				var result = await _appUserManager.UserProfileUpdateAsync(myProfileUpdateDto);
				if (result.isTrue && result.identityResult.Succeeded && result.validationResult.IsValid)
				{
					_toast.AddSuccessToastMessage("Profil Güncellendi.", new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "Home");
				}
				else
				{
					_toast.AddErrorToastMessage("Bir Hata Oluştu.", new ToastrOptions { Title = "İşlem Başarısız" });
					if (result.identityResult != null)
					{
						result.identityResult.AddToIdentityModelState(this.ModelState);
					}
					else if (result.validationResult != null)
					{
						result.validationResult.AddToModelState(this.ModelState);
					}
					return View(myProfileUpdateDto);
				}
			}
			return NotFound();
		}
	}
}
