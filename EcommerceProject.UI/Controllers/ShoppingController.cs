using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.Models.ShoppingTools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;

namespace EcommerceProject.UI.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProductManager _productManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;
		private readonly IToastNotification _toast;

		public ShoppingController(IProductManager productManager, IHttpContextAccessor httpContextAccessor, IToastNotification toast)
		{
			_productManager = productManager;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
			_toast = toast;
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

			return RedirectToAction("GetCartInfo", "Shopping", new { addProductMessage = cartItem.Name});
        }

        [HttpGet]
        public IActionResult GetCartInfo(string addProductMessage = null!,string deleteProductMessage = null!,string deleteProductCompletelyMessage = null!)
        {
            if (HttpContext.Session.GetObject<Cart>("shoppingCart") != null)
            {
                Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
                if (addProductMessage != null)
                {
					_toast.AddSuccessToastMessage($"{addProductMessage} sepete eklenmiştir.", new ToastrOptions { Title = "İşlem Başarılı" });
				}
                else if(deleteProductMessage != null)
                {
					_toast.AddSuccessToastMessage($"{deleteProductMessage} sepetten silinmiştir.", new ToastrOptions { Title = "İşlem Başarılı" });
				}
                else if(deleteProductCompletelyMessage != null)
                {
					_toast.AddSuccessToastMessage($"{deleteProductCompletelyMessage} sepetten kaldırılmıştır.", new ToastrOptions { Title = "İşlem Başarılı" });
				}
                return PartialView("_ShoppingCart", cart);
            }
            else
            {
				return PartialView("_ShoppingCart");
            }
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int id)
        {
            if (HttpContext.Session.GetObject<Cart>("shoppingCart") != null)
            {
                Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
                cart.RemoveFromCart(id);
                HttpContext.Session.SetObject("shoppingCart", cart);

				return RedirectToAction("GetCartInfo", "Shopping", new { deleteProductMessage = cart.MyCart.Find(x=>x.ID==id).Name });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteProductCompletely(int id)
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
            var message = cart.MyCart.Find(x => x.ID == id).Name;
			cart.RemoveProductCompletely(id);
            HttpContext.Session.SetObject("shoppingCart", cart);
			
			return RedirectToAction("GetCartInfo", "Shopping", new { deleteProductCompletelyMessage = message });
        }

        [HttpGet]
        public IActionResult CartPage()
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");

            return View(cart);
        }
    }
}
