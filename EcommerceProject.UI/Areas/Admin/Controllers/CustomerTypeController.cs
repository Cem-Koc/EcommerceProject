using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.BLL.ManagerServices.Concretes;
using EcommerceProject.ENTITIES.Dtos.CustomerTypes;
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
    public class CustomerTypeController : Controller
	{
		private readonly ICustomerTypeManager _customerTypeManager;
		private readonly IValidator<CustomerType> _validator;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toast;
		public CustomerTypeController(ICustomerTypeManager customerTypeManager, IValidator<CustomerType> validator, IMapper mapper, IToastNotification toast)
		{
			_customerTypeManager = customerTypeManager;
			_validator = validator;
			_mapper = mapper;
			_toast = toast;
		}


		public async Task<IActionResult> Index()
		{
			var customerType = await _customerTypeManager.GetAllCustomerTypesNonDeletedAsync();
			return View(customerType);
		}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerTypeAddDto customerTypeAddDto)
        {
            var map = _mapper.Map<CustomerType>(customerTypeAddDto);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var createCustomerTypeResult = await _customerTypeManager.CreateCustomerTypeAsync(customerTypeAddDto);
                if (createCustomerTypeResult)
                {
                    _toast.AddSuccessToastMessage(Messages.CustomerType.Add(customerTypeAddDto.CustomerTypeName), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "CustomerType", new { Area = "Admin" });
                }
                else
                {
                    _toast.AddErrorToastMessage(Messages.CustomerType.AddError(customerTypeAddDto.CustomerTypeName), new ToastrOptions { Title = "İşlem Başarısız" });
                }
            }
            result.AddToModelState(this.ModelState);
            return View();
        }

		[HttpGet]
		public async Task<IActionResult> Update(int customerTypeID)
		{
			var customerType = await _customerTypeManager.FindAsync(customerTypeID);
			var customerTypeUpdateDto = _mapper.Map<CustomerTypeUpdateDto>(customerType);
			return View(customerTypeUpdateDto);
		}

		[HttpPost]
		public async Task<IActionResult> Update(CustomerTypeUpdateDto customerTypeUpdateDto)
		{
			var map = _mapper.Map<CustomerType>(customerTypeUpdateDto);
			var result = await _validator.ValidateAsync(map);

			if (result.IsValid)
			{
				var createCustomerTypeResult = await _customerTypeManager.UpdateCustomerTypeAsync(customerTypeUpdateDto);
				if (createCustomerTypeResult)
				{
					_toast.AddSuccessToastMessage(Messages.CustomerType.Update(customerTypeUpdateDto.CustomerTypeName), new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "CustomerType", new { Area = "Admin" });
				}
				else
				{
					_toast.AddErrorToastMessage(Messages.CustomerType.UpdateError(customerTypeUpdateDto.CustomerTypeName), new ToastrOptions { Title = "İşlem Başarısız" });
				}
			}
			result.AddToModelState(this.ModelState);
			return View();
		}
		public async Task<IActionResult> Delete(int customerTypeID)
		{
			var customerTypeName = await _customerTypeManager.SafeDeleteCustomerTypeAsync(customerTypeID);
			_toast.AddSuccessToastMessage(Messages.CustomerType.Delete(customerTypeName), new ToastrOptions { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "CustomerType", new { Area = "Admin" });
		}
	}
}
