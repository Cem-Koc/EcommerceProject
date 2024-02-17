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

		public HomeController(IProductManager productManager)
		{
			_productManager = productManager;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
