using EcommerceProject.ENTITIES.Dtos.Products;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IProductManager
    {
		Task<List<ProductDto>> GetAllProductsWithCategoryNonDeletedAsync();
		Task<ProductDto> GetProductWithCategoryNonDeletedAsync(int productID);
        Task CreateProductAsync(ProductAddDto productAddDto);
		Task<string> UpdateProductAsync(ProductUpdateDto productUpdateDto);
		Task<string> SafeDeleteProductAsync(int productID);

		IQueryable<ProductDto> GetAll();
		IQueryable<Product> GetActives();
		IQueryable<Product> GetModifieds();
		IQueryable<Product> GetPassives();

		//Modify Commands
		void Add(Product item);
		Task AddAsync(Product item);
		void AddRange(List<Product> list);
		Task AddRangeAsync(List<Product> list);
		Task Update(Product item);
		Task UpdateRange(List<Product> list);
		void Delete(Product item);
		void DeleteRange(List<Product> list);
		void Destroy(Product item);
		void DestroyRange(List<Product> list);

		//Linq Commands
		IQueryable<Product> Where(Expression<Func<Product, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<Product, bool>> exp);
		Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<Product, X>> exp);

		//Find
		Task<Product> FindAsync(int id);
	}
}
