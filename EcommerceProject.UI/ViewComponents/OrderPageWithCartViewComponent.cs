using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.UI.Models.ShoppingTools;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
    public class OrderPageWithCartViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
			Cart cart = HttpContext.Session.GetObject<Cart>("shoppingCart");
			return View(cart);
        }
    }
}
