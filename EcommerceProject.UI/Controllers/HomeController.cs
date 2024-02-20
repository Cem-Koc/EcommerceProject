using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IProductManager _productManager;

		public HomeController(ILogger<HomeController> logger,IProductManager productManager)
        {
            _logger = logger;
			_productManager = productManager;
		}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}