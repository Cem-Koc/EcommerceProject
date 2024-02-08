using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.WebAPI.Models.Products.RequestModels;
using EcommerceProject.WebAPI.Models.Products.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel item)
        {
            Product p = new()
            {
                ProductName = item.ProductName,
                UnitPrice = item.UnitPrice,
                CategoryID = item.CategoryID
            };

            _productManager.Add(p);
            return Ok("Ürün başarılı bir şekilde kaydedildi.");
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? categoryID)
        {
            List<ProductResponseModel> products;
            if(categoryID.HasValue)
            {
                products = _productManager.Where(x => x.CategoryID == categoryID).Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }
            else
            {
                products = _productManager.Select(x => new ProductResponseModel
                {
                    ID = x.ID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    CategoryName = x.Category.CategoryName
                }).ToList();
            }

            return Ok(products);
        }
    }
}
