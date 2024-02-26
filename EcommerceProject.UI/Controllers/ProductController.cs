using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Dtos.Products;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> ProductList(int id, int? CategorySideMenuSelectedID)
        {
            var model = await _productManager.GetProductsAllDetail(id, CategorySideMenuSelectedID);
            return View(model);
        }

		[HttpPost]
        public async Task<IActionResult> GetFilteredProducts(FilterProductDto filterProductDto)
        {
            var productList = await _productManager.FilterProduct(filterProductDto);

			return PartialView("_ProductList", productList);
		}

        [HttpGet]
        public async Task<IActionResult> GetByIdProductDetail(int id)
        {
            var model = await _productManager.GetByIdProductDetail(id);
			return View(model);
        }

	}
}
