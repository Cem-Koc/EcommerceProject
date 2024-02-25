using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
    public class MenDressListCategoriesViewComponent:ViewComponent
    {
        private readonly IProductManager _productManager;
        public MenDressListCategoriesViewComponent(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _productManager.GetCategoriesByCustomerTypeId(2);
            return View(result);
        }
    }
}
