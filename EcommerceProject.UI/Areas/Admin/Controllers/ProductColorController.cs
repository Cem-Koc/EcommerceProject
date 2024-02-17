using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.BLL.ManagerServices.Concretes;
using EcommerceProject.ENTITIES.Dtos.ProductColors;
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
    public class ProductColorController : Controller
	{
		private readonly IProductColorManager _productColorManager;
		private readonly IValidator<ProductColor> _validator;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toast;
		public ProductColorController(IProductColorManager productColorManager, IValidator<ProductColor> validator, IMapper mapper, IToastNotification toast)
		{
			_productColorManager = productColorManager;
			_validator = validator;
			_mapper = mapper;
			_toast = toast;
		}
		public async Task<IActionResult> Index()
		{
			var productColor = await _productColorManager.GetProductColorsNonDeletedAsync();
			return View(productColor);
		}
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductColorAddDto productColorAddDto)
        {
            var map = _mapper.Map<ProductColor>(productColorAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var createProductColorResult = await _productColorManager.CreateProductColorAsync(productColorAddDto);
                if (createProductColorResult)
                {
                    _toast.AddSuccessToastMessage(Messages.ProductColor.Add(productColorAddDto.Color), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "ProductColor", new { Area = "Admin" });
                }
                else
                {
                    _toast.AddErrorToastMessage(Messages.ProductColor.AddError(productColorAddDto.Color), new ToastrOptions { Title = "İşlem Başarısız" });
                }
            }
            result.AddToModelState(this.ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int productColorID)
        {
            var productColor = await _productColorManager.FindAsync(productColorID);
            var productColorUpdateDto = _mapper.Map<ProductColorUpdateDto>(productColor);
            return View(productColorUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductColorUpdateDto productColorUpdateDto)
        {
            var map = _mapper.Map<ProductColor>(productColorUpdateDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var createProductColorResult = await _productColorManager.UpdateProductColorAsync(productColorUpdateDto);
                if (createProductColorResult)
                {
                    _toast.AddSuccessToastMessage(Messages.ProductColor.Update(productColorUpdateDto.Color), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "ProductColor", new { Area = "Admin" });
                }
                else
                {
                    _toast.AddErrorToastMessage(Messages.ProductColor.UpdateError(productColorUpdateDto.Color), new ToastrOptions { Title = "İşlem Başarısız" });
                }
            }
            result.AddToModelState(this.ModelState);
            return View();
        }
        public async Task<IActionResult> Delete(int productColorID)
        {
            var productColorName = await _productColorManager.SafeDeleteProductColorAsync(productColorID);
            _toast.AddSuccessToastMessage(Messages.ProductColor.Delete(productColorName), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "ProductColor", new { Area = "Admin" });
        }
    }
}
