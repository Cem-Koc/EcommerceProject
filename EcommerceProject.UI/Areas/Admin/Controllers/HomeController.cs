using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
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
