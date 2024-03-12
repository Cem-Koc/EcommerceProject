using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
    public class RecommendedProductViewComponent:ViewComponent
    {
		private readonly IProductManager _productManager;

		public RecommendedProductViewComponent(IProductManager productManager)
		{
			_productManager = productManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int customerTypeId)
		{
			var result = await _productManager.RecommendedProductsByCustomerType(customerTypeId);
			return View(result);
		}
	}
}
