using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
	public class NewArrivalsViewComponent:ViewComponent
	{
		private readonly IProductManager _productManager;

        public NewArrivalsViewComponent(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _productManager.NewArrivalsList();
			return View(result);
		}
	}
}
