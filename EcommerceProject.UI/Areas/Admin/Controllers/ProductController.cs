using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Dtos.Images;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.Areas.Admin.Consts;
using EcommerceProject.UI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConsts.Admin)]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IProductSizeManager _productSizeManager;
        private readonly IProductColorManager _productColorManager;
        private readonly ICustomerTypeManager _customerTypeManager;
        private readonly IMapper _mapper;
		private readonly IValidator<Product> _validator;
		private readonly IToastNotification _toast;
		private readonly IImageDetailManager _imageDetailManager;
		private readonly IImageManager _imageManager;

		public ProductController(IProductManager productManager,ICategoryManager categoryManager,IProductSizeManager productSizeManager,IProductColorManager productColorManager,ICustomerTypeManager customerTypeManager,IMapper mapper,IValidator<Product> validator,IToastNotification toast,IImageDetailManager imageDetailManager,IImageManager imageManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
            _productSizeManager = productSizeManager;
            _productColorManager = productColorManager;
            _customerTypeManager = customerTypeManager;
            _mapper = mapper;
			_validator = validator;
			_toast = toast;
			_imageDetailManager = imageDetailManager;
			_imageManager = imageManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
        {
            var products = await _productManager.GetAllProductsWithCategoryNonDeletedAsync();
            return View(products);
        }

		[HttpGet]
		public async Task<IActionResult> DeletedProducts()
		{
			var products = await _productManager.GetAllProductsWithCategoryDeletedAsync();
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
                _toast.AddSuccessToastMessage(Messages.Product.Add(productAddDto.ProductName),new ToastrOptions { Title = "İşlem Başarılı"});
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
            var imageDetails = _imageDetailManager.GetImageDetailsByProductID(productID);
            var images = _imageManager.GetImageByImageDetails(imageDetails);

            var productUpdateDto = _mapper.Map<ProductUpdateDto>(product);
            productUpdateDto.Categories = categories;
            productUpdateDto.ProductSizes = productSizes;
            productUpdateDto.ProductColors = productColors;
            productUpdateDto.CustomerTypes = customerTypes;
            productUpdateDto.ImageDetails = imageDetails;
            productUpdateDto.Images = images;

            return View(productUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
			var map = _mapper.Map<Product>(productUpdateDto);
			var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				var productName = await _productManager.UpdateProductAsync(productUpdateDto);
                _toast.AddSuccessToastMessage(Messages.Product.Update(productName),new ToastrOptions { Title = "İşlem Başarılı"});
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

            productUpdateDto.Categories = categories;
            productUpdateDto.ProductSizes = productSizes;
            productUpdateDto.ProductColors = productColors;
            productUpdateDto.CustomerTypes = customerTypes;

            return View(productUpdateDto);
		}

        public async Task<IActionResult> Delete(int productID)
        {
            var productName = await _productManager.SafeDeleteProductAsync(productID);
			_toast.AddSuccessToastMessage(Messages.Product.Delete(productName), new ToastrOptions { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Product", new { Area = "Admin" });
		}

        public async Task<IActionResult> UndoDelete(int productID)
        {
            var productName = await _productManager.UndoDeleteProductAsync(productID);
            _toast.AddSuccessToastMessage(Messages.Product.UndoDelete(productName), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }

        [HttpGet]
		public async Task<IActionResult> ImagesUpload(int productID)
        {
			var product = await _productManager.FindAsync(productID);
			var imageOperationsDto = _mapper.Map<ImagesOperationsDto>(product);

            var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
            var productSizes = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
            var productColors = await _productColorManager.GetProductColorsNonDeletedAsync();
            var customerTypes = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();

            imageOperationsDto.CustomerTypes = customerTypes;
            imageOperationsDto.ProductColors = productColors;
            imageOperationsDto.ProductSizes = productSizes;
            imageOperationsDto.Categories = categories;
            return View(imageOperationsDto);
		}

        [HttpPost]
		public async Task<IActionResult> ImagesUpload(ImagesOperationsDto imageOperationsDto)
        {
            await _productManager.ProductImageUpload(imageOperationsDto);
            return RedirectToAction("ImagesUpload", "Product", new { @productID = imageOperationsDto.ID });
		}

		[HttpGet]
		public async Task<IActionResult> ImagesUpdate(int productID)
		{
			var product = await _productManager.FindAsync(productID);
			var imageOperationsDto = _mapper.Map<ImagesOperationsDto>(product);

			var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
			var productSizes = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
			var productColors = await _productColorManager.GetProductColorsNonDeletedAsync();
			var customerTypes = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();
            var imageDetails = _imageDetailManager.GetImageDetailsByProductID(productID);
            var images = _imageManager.GetImageByImageDetails(imageDetails);

            imageOperationsDto.CustomerTypes = customerTypes;
			imageOperationsDto.ProductColors = productColors;
			imageOperationsDto.ProductSizes = productSizes;
			imageOperationsDto.Categories = categories;
            imageOperationsDto.ImageDetails = imageDetails;
            imageOperationsDto.Images = images;
            return View(imageOperationsDto);
		}

        [HttpPost]
        public async Task<IActionResult> ImagesUpdate(ImagesOperationsDto imageOperationsDto)
        {
            await _productManager.ProductImageUpdate(imageOperationsDto);
            return RedirectToAction("Index", "Product", new { Area = "Admin" });
        }
    }
}
