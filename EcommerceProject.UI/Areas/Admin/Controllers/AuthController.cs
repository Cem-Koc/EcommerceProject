using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.ENTITIES.Dtos.Users;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
