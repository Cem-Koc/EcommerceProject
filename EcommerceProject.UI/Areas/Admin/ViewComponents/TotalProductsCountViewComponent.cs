using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.ViewComponents
{
    public class TotalProductsCountViewComponent : ViewComponent
    {
        private readonly IProductManager _productManager;

        public TotalProductsCountViewComponent(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _productManager.GetAll().Count();
            return View(result);
        }
    }
}
