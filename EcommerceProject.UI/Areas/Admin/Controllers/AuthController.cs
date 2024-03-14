using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toast;
        private readonly IValidator<AppUser> _validator;
        private readonly IAppUserManager _appUserManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IToastNotification toast, IValidator<AppUser> validator, IAppUserManager appUserManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _toast = toast;
            _validator = validator;
            _appUserManager = appUserManager;
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var map = _mapper.Map<AppUser>(userRegisterDto);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _appUserManager.GetAllRolesAsync();

            if (ModelState.IsValid)
            {
                var userAddDto = _mapper.Map<UserAddDto>(userRegisterDto);
                userAddDto.RoleId = roles.Where(x=>x.Name == "User").Select(x=>x.Id).First();
                var result = await _appUserManager.RegisterUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    _toast.AddSuccessToastMessage(Messages.User.Register(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,userLoginDto.Password,userLoginDto.RememberMe,false);
                    if (result.Succeeded)
                    {

						if (_userManager.GetRolesAsync(user).Result.FirstOrDefault() == "Admin")
                        {
							return RedirectToAction("Index", "Home", new { Area = "Admin" });
						}
                        else 
                        {
							return RedirectToAction("Index", "Home", new { Area = "" });
						}         

					}
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresini veya şifreniz hatalıdır.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresini veya şifreniz hatalıdır.");
                    return View();
                }
            }
            else
            {
                return View();
            }            
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
