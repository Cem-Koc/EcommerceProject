using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.WebAPI.Models.AppUsers.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IAppUserManager _appUserManager;

        public RegisterController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel item)
        {
            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.Password,
            };

            bool result = await _appUserManager.CreateUserAsync(appUser);
            if (result)
            {
                return Ok("Kullanıcı ekleme basarılı");
            }
            return BadRequest("Kullanıcı ekleme kısmında bir sorunla karsılasıldı");
        }
    }
}
