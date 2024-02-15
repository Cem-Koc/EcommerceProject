using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.BLL.ManagerServices.Concretes;
using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.UI.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace EcommerceProject.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryManager _categoryManager;
		private readonly IValidator<Category> _validator;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toast;

		public CategoryController(ICategoryManager categoryManager,IValidator<Category> validator,IMapper mapper,IToastNotification toast)
        {
            _categoryManager = categoryManager;
			_validator = validator;
			_mapper = mapper;
			_toast = toast;
		}

        public async Task<IActionResult> Index()
		{
			var categories = await _categoryManager.GetAllCategoriesNonDeletedAsync();
			return View(categories);
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
		{
			var map = _mapper.Map<Category>(categoryAddDto);
			var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
			{
                var createCategoryResult = await _categoryManager.CreateCategoryAsync(categoryAddDto);
                if (createCategoryResult)
                {
					_toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.CategoryName), new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "Category", new { Area = "Admin" });
				}
                else
                {
					_toast.AddErrorToastMessage(Messages.Category.AddError(categoryAddDto.CategoryName), new ToastrOptions { Title = "İşlem Başarısız" });
				}
            }
			result.AddToModelState(this.ModelState);
			return View();
        }

		[HttpGet]
		public async Task<IActionResult> Update(int categoryID)
		{
			var category = await _categoryManager.FindAsync(categoryID);
			var categoryUpdateDto = _mapper.Map<CategoryUpdateDto>(category);
			return View(categoryUpdateDto);
		}

		[HttpPost]
		public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
		{
			var map = _mapper.Map<Category>(categoryUpdateDto);
			var result = await _validator.ValidateAsync(map);

			if (result.IsValid)
			{
				var createCategoryResult = await _categoryManager.UpdateCategoryAsync(categoryUpdateDto);
				if (createCategoryResult)
				{
					_toast.AddSuccessToastMessage(Messages.Category.Update(categoryUpdateDto.CategoryName), new ToastrOptions { Title = "İşlem Başarılı" });
					return RedirectToAction("Index", "Category", new { Area = "Admin" });
				}
				else
				{
					_toast.AddErrorToastMessage(Messages.Category.UpdateError(categoryUpdateDto.CategoryName), new ToastrOptions { Title = "İşlem Başarısız" });
				}
			}
			result.AddToModelState(this.ModelState);
			return View();
		}

		public async Task<IActionResult> Delete(int categoryID)
		{
			var categoryName = await _categoryManager.SafeDeleteCategoryAsync(categoryID);
			_toast.AddSuccessToastMessage(Messages.Category.Delete(categoryName), new ToastrOptions { Title = "İşlem Başarılı" });
			return RedirectToAction("Index", "Category", new { Area = "Admin" });
		}
	}
}
