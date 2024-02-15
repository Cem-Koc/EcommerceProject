using EcommerceProject.ENTITIES.Dtos.Categories;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface ICategoryManager
    {
		Task<string> SafeDeleteCategoryAsync(int categoryID);
		Task<bool> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
		Task<bool> CreateCategoryAsync(CategoryAddDto categoryAddDto);
		Task<List<CategoryDto>> GetAllCategoriesNonDeletedAsync();
        IQueryable<Category> GetAll();
		IQueryable<Category> GetActives();
		IQueryable<Category> GetModifieds();
		IQueryable<Category> GetPassives();

		//Modify Commands
		void Add(Category item);
		Task AddAsync(Category item);
		void AddRange(List<Category> list);
		Task AddRangeAsync(List<Category> list);
		Task Update(Category item);
		Task UpdateRange(List<Category> list);
		void Delete(Category item);
		void DeleteRange(List<Category> list);
		void Destroy(Category item);
		void DestroyRange(List<Category> list);

		//Linq Commands
		IQueryable<Category> Where(Expression<Func<Category, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<Category, bool>> exp);
		Task<Category> FirstOrDefaultAsync(Expression<Func<Category, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<Category, X>> exp);

		//Find
		Task<Category> FindAsync(int id);
	}
}
