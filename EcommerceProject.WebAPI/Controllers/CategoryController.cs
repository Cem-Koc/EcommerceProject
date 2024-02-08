using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.ENTITIES.Models;
using EcommerceProject.WebAPI.Models.Categories.RequestModels;
using EcommerceProject.WebAPI.Models.Categories.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestModel item)
        {
            Category c = new()
            {
                CategoryName = item.CategoryName,
                Description = item.Description
            };
            await _categoryManager.AddAsync(c);
            return Ok("Kategori başarılı bir şekilde oluşturuldu.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            List<CategoryResponseModel> categories = _categoryManager.Select(x=> new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                CategoryID = x.ID
            }).ToList();

            return Ok(categories);
        }
    }
}
