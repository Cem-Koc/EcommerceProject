using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IProductSizeManager _productSizeManager;
        private readonly IProductColorManager _productColorManager;
        private readonly ICustomerTypeManager _customerTypeManager;
        private readonly IMapper _mapper;
		private readonly IValidator<Product> _validator;

		public ProductController(IProductManager productManager,ICategoryManager categoryManager,IProductSizeManager productSizeManager,IProductColorManager productColorManager,ICustomerTypeManager customerTypeManager,IMapper mapper,IValidator<Product> validator)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _productSizeManager = productSizeManager;
            _productColorManager = productColorManager;
            _customerTypeManager = customerTypeManager;
            _mapper = mapper;
			_validator = validator;
		}
        public async Task<IActionResult> Index()
        {
            var products = await _productManager.GetAllProductsWithCategoryNonDeletedAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
            var productSizes = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
            var productColors = await _productColorManager.GetProductColorsNonDeletedAsync();
            var customerTypes = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();

            return View(new ProductAddDto { Categories = categories,ProductSizes = productSizes,ProductColors = productColors,CustomerTypes = customerTypes});
        }

		[HttpPost]
		public async Task<IActionResult> Add(ProductAddDto productAddDto)
		{
            var map = _mapper.Map<Product>(productAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _productManager.CreateProductAsync(productAddDto);
				return RedirectToAction("Index", "Product", new { Area = "Admin" });
			}
            else
            {
				result.AddToModelState(this.ModelState);
			}

			var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
			var productSizes = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
			var productColors = await _productColorManager.GetProductColorsNonDeletedAsync();
			var customerTypes = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();

			return View(new ProductAddDto { Categories = categories, ProductSizes = productSizes, ProductColors = productColors, CustomerTypes = customerTypes });
		}

        [HttpGet]
        public async Task<IActionResult> Update(int productID)
        {
            var product = await _productManager.GetProductWithCategoryNonDeletedAsync(productID);
            var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
            var productSizes = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
            var productColors = await _productColorManager.GetProductColorsNonDeletedAsync();
            var customerTypes = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();

            var productUpdateDto = _mapper.Map<ProductUpdateDto>(product);
            productUpdateDto.Categories = categories;
            productUpdateDto.ProductSizes = productSizes;
            productUpdateDto.ProductColors = productColors;
            productUpdateDto.CustomerTypes = customerTypes;

            return View(productUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
			var map = _mapper.Map<Product>(productUpdateDto);
			var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _productManager.UpdateProductAsync(productUpdateDto);
			}
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
			var productSizes = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
			var productColors = await _productColorManager.GetProductColorsNonDeletedAsync();
			var customerTypes = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();

            productUpdateDto.Categories = categories;
            productUpdateDto.ProductSizes = productSizes;
            productUpdateDto.ProductColors = productColors;
            productUpdateDto.CustomerTypes = customerTypes;

            return View(productUpdateDto);
		}

        public async Task<IActionResult> Delete(int productID)
        {
            await _productManager.SafeDeleteProductAsync(productID);
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
		}
	}
}
