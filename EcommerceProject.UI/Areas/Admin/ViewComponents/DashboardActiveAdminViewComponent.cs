using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.ViewComponents
{
    public class DashboardActiveAdminViewComponent:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardActiveAdminViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInAdmin = await _userManager.GetUserAsync(HttpContext.User);
            return View(loggedInAdmin);
        }
    }
}
