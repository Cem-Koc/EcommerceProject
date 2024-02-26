using AutoMapper;
using EcommerceProject.BLL.DependencyResolvers;
using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
    public class CategoryManager : ICategoryManager
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = _httpContextAccessor.HttpContext.User;
		}

		public async Task<List<CategoriesByCustomerTypeDto>> CategoriesByCustomerType()
		{
			var product = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted, x => x.Category, x => x.CustomerType);

			var productCustomerType = product.Select(x => x.CustomerType).Distinct().ToList();

			List<CategoriesByCustomerTypeDto> categoriesByCustomerTypeDto = new List<CategoriesByCustomerTypeDto>();

			foreach (var item in productCustomerType)
            {
				var categories = product.Where(x => x.CustomerTypeID == item.ID).Select(x => x.Category).Distinct().ToList();
				var map = _mapper.Map<List<CategorySideMenuDto>>(categories);

				CategoriesByCustomerTypeDto categoriesByCustomerType = new CategoriesByCustomerTypeDto
				{
					Categories = map,
					CustomerTypeName = item.CustomerTypeName,
					CustomerTypeId = item.ID					
				};

				categoriesByCustomerTypeDto.Add(categoriesByCustomerType);
			}
            return categoriesByCustomerTypeDto;
		}
		public async Task<string> SafeDeleteCategoryAsync(int categoryID)
		{
			var category = await _unitOfWork.GetRepository<Category>().FindAsync(categoryID);
			var user = _user.GetLoggedInUserEmail();
			var categoryName = category.CategoryName;
			category.DeletedBy = user;
			category.DeletedDate = DateTime.Now;
			_unitOfWork.GetRepository<Category>().Delete(category);
			await _unitOfWork.SaveAsync();

			return categoryName;
		}
		public async Task<bool> CreateCategoryAsync(CategoryAddDto categoryAddDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var categoryResult = _unitOfWork.GetRepository<Category>().Where(x => x.CategoryName == categoryAddDto.CategoryName && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			if (categoryResult.Count == 0)
            {
				Category category = new(categoryAddDto.CategoryName, user);
				await _unitOfWork.GetRepository<Category>().AddAsync(category);
				await _unitOfWork.SaveAsync();
				return true;
			}
            else
            {
				return false;
            }
        }
		public async Task<bool> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
		{
			var user = _user.GetLoggedInUserEmail();

			var categoryResult = _unitOfWork.GetRepository<Category>().Where(x => x.CategoryName == categoryUpdateDto.CategoryName && x.Status != ENTITIES.Enums.DataStatus.Deleted).ToList();

			var category = await _unitOfWork.GetRepository<Category>().GetAsync(x => x.Status != ENTITIES.Enums.DataStatus.Deleted && x.ID == categoryUpdateDto.ID);

			if (categoryResult.Count == 0)
			{
				category.CategoryName = categoryUpdateDto.CategoryName;
				category.ModifiedBy = user;
				category.ModifiedDate = DateTime.Now;
				await _unitOfWork.GetRepository<Category>().Update(category);
				await _unitOfWork.SaveAsync();
				return true;
			}
			else
			{
				return false;
			}
		}
		public void Add(Category item)
		{
			_unitOfWork.GetRepository<Category>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(Category item)
		{
			await _unitOfWork.GetRepository<Category>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<Category> list)
		{
			_unitOfWork.GetRepository<Category>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<Category> list)
		{
			await _unitOfWork.GetRepository<Category>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<Category, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Category>().AnyAsync(exp);
		}

		public void Delete(Category item)
		{
			_unitOfWork.GetRepository<Category>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<Category> list)
		{
			_unitOfWork.GetRepository<Category>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(Category item)
		{
			_unitOfWork.GetRepository<Category>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<Category> list)
		{
			_unitOfWork.GetRepository<Category>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<Category> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<Category>().FindAsync(id);
		}

		public async Task<Category> FirstOrDefaultAsync(Expression<Func<Category, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Category>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<Category> GetActives()
		{
			return _unitOfWork.GetRepository<Category>().GetActives();
		}

		public IQueryable<Category> GetAll()
		{
			return _unitOfWork.GetRepository<Category>().GetAll();
		}

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(x=>x.Status != ENTITIES.Enums.DataStatus.Deleted);
			var map = _mapper.Map<List<CategoryDto>>(categories);
			return map;
        }

        public IQueryable<Category> GetModifieds()
		{
			return _unitOfWork.GetRepository<Category>().GetModifieds();
		}

		public IQueryable<Category> GetPassives()
		{
			return _unitOfWork.GetRepository<Category>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<Category, X>> exp)
		{
			return _unitOfWork.GetRepository<Category>().Select(exp);
		}

		public async Task Update(Category item)
		{
			await _unitOfWork.GetRepository<Category>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<Category> list)
		{
			await _unitOfWork.GetRepository<Category>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<Category> Where(Expression<Func<Category, bool>> exp)
		{
			return _unitOfWork.GetRepository<Category>().Where(exp);
		}
	}
}