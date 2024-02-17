using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.BLL.ManagerServices.Concretes;
using EcommerceProject.ENTITIES.Dtos.ProductSizes;
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
    public class ProductSizeController : Controller
	{
		private readonly IProductSizeManager _productSizeManager;
		private readonly IValidator<ProductSize> _validator;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toast;
		public ProductSizeController(IProductSizeManager productSizeManager, IValidator<ProductSize> validator, IMapper mapper, IToastNotification toast)
		{
			_productSizeManager = productSizeManager;
			_validator = validator;
			_mapper = mapper;
			_toast = toast;
		}
		public async Task<IActionResult> Index()
		{
			var productSize = await _productSizeManager.GetAllProductSizesNonDeletedAsync();
			return View(productSize);
		}
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductSizeAddDto productSizeAddDto)
        {
            var map = _mapper.Map<ProductSize>(productSizeAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var createProductSizeResult = await _productSizeManager.CreateProductSizeAsync(productSizeAddDto);
                if (createProductSizeResult)
                {
                    _toast.AddSuccessToastMessage(Messages.ProductSize.Add(productSizeAddDto.Size), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "ProductSize", new { Area = "Admin" });
                }
                else
                {
                    _toast.AddErrorToastMessage(Messages.ProductSize.AddError(productSizeAddDto.Size), new ToastrOptions { Title = "İşlem Başarısız" });
                }
            }
            result.AddToModelState(this.ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int productSizeID)
        {
            var productSize = await _productSizeManager.FindAsync(productSizeID);
            var productSizeUpdateDto = _mapper.Map<ProductSizeUpdateDto>(productSize);
            return View(productSizeUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductSizeUpdateDto productSizeUpdateDto)
        {
            var map = _mapper.Map<ProductSize>(productSizeUpdateDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var createProductSizeResult = await _productSizeManager.UpdateProductSizeAsync(productSizeUpdateDto);
                if (createProductSizeResult)
                {
                    _toast.AddSuccessToastMessage(Messages.ProductSize.Update(productSizeUpdateDto.Size), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "ProductSize", new { Area = "Admin" });
                }
                else
                {
                    _toast.AddErrorToastMessage(Messages.ProductSize.UpdateError(productSizeUpdateDto.Size), new ToastrOptions { Title = "İşlem Başarısız" });
                }
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
        public async Task<IActionResult> Delete(int productSizeID)
        {
            var productSizeName = await _productSizeManager.SafeDeleteProductSizeAsync(productSizeID);
            _toast.AddSuccessToastMessage(Messages.ProductSize.Delete(productSizeName), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "ProductSize", new { Area = "Admin" });
        }
    }
}
