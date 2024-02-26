using EcommerceProject.BLL.ManagerServices.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.UI.ViewComponents
{
	public class CategoriesSideMenuViewComponent:ViewComponent
	{
		private readonly ICategoryManager _categoryManager;

		public CategoriesSideMenuViewComponent(ICategoryManager categoryManager)
		{
			_categoryManager = categoryManager;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var result = await _categoryManager.CategoriesByCustomerType();
			return View(result);
		}
	}
}
