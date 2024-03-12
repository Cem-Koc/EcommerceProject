using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.UI.Areas.Admin.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class HomeController : Controller
	{
		private readonly IProductManager _productManager;
		private readonly IOrderManager _orderManager;

        public HomeController(IProductManager productManager, IOrderManager orderManager)
        {
            _productManager = productManager;
            _orderManager = orderManager;
        }

        public async Task<IActionResult> Index()
		{
            
            var result = await _orderManager.WeeklySoldProducts();
            return View(result);
		}
	}
}
