using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.Models.ShoppingTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceProject.UI.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProductManager _productManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public ShoppingController(IProductManager productManager, IHttpContextAccessor httpContextAccessor)
		{
			_productManager = productManager;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
		}

		[HttpPost]
        public async Task<IActionResult> AddProductToCart(int id, string imageFileName)
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart") == null ? new Cart() : HttpContext.Session.GetObject<Cart>("shoppingCart");

            Product product = await _productManager.FindAsync(id);

            CartItem cartItem = new()
            {
                ID = product.ID,
                Name = product.ProductName,
                Price = product.SalePrice,
                ImageFileName = imageFileName,
                ProductColor = product.ProductColor.Color,
                ProductSize = product.ProductSize.Size
            };

            cart.AddToCart(cartItem);
            HttpContext.Session.SetObject("shoppingCart", cart);

            return RedirectToAction("GetCartInfo", "Shopping");
        }

        [HttpGet]
        public async Task<IActionResult> GetCartInfo()
        {
            if (HttpContext.Session.GetObject<Cart>("shoppingCart") != null)
            {
                Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
                return PartialView("_ShoppingCart", cart);
            }
            else
            {
                return PartialView("_ShoppingCart");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("shoppingCart") != null)
            {
                Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
                cart.RemoveFromCart(id);
                HttpContext.Session.SetObject("shoppingCart", cart);
                return RedirectToAction("GetCartInfo", "Shopping");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductCompletely(int id)
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
            cart.RemoveProductCompletely(id);
            HttpContext.Session.SetObject("shoppingCart", cart);
            return RedirectToAction("GetCartInfo", "Shopping");
        }

        [HttpGet]
        public async Task<IActionResult> CartPage()
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
            return View(cart);
        }
    }
}
