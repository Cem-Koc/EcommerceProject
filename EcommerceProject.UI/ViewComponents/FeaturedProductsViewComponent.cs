using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
    public class FeaturedProductsViewComponent:ViewComponent
    {
        private readonly IProductManager _productManager;

        public FeaturedProductsViewComponent(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _productManager.FeaturedProductsList();
            return View(result);
        }
    }
}
