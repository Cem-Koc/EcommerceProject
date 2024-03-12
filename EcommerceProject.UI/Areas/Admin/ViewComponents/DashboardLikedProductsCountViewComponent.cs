using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.ViewComponents
{
    public class DashboardLikedProductsCountViewComponent : ViewComponent
    {
        private readonly ILikedProductManager _likedProductManager;

        public DashboardLikedProductsCountViewComponent(ILikedProductManager likedProductManager)
        {
            _likedProductManager = likedProductManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _likedProductManager.GetAll().Count();
            return View(result);
        }
    }
}
