using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
    public class ProductCommentsViewComponent:ViewComponent
    {
        private readonly IProductCommentManager _productCommentManager;

        public ProductCommentsViewComponent(IProductCommentManager productCommentManager)
        {
            _productCommentManager = productCommentManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productCode)
        {
            var result = await _productCommentManager.GetCommentsByProductCode(productCode);
            return View(result);
        }
    }
}
