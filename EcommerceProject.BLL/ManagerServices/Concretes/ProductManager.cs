using EcommerceProject.BLL.ManagerServices.Abstracts;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.DAL.UnitOfWorks;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Concretes
{
	public class ProductManager : IProductManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Add(Product item)
		{
			_unitOfWork.GetRepository<Product>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(Product item)
		{
			await _unitOfWork.GetRepository<Product>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<Product> list)
		{
			_unitOfWork.GetRepository<Product>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<Product> list)
		{
			await _unitOfWork.GetRepository<Product>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<Product, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Product>().AnyAsync(exp);
		}

		public void Delete(Product item)
		{
			_unitOfWork.GetRepository<Product>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<Product> list)
		{
			_unitOfWork.GetRepository<Product>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(Product item)
		{
			_unitOfWork.GetRepository<Product>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<Product> list)
		{
			_unitOfWork.GetRepository<Product>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<Product> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<Product>().FindAsync(id);
		}

		public async Task<Product> FirstOrDefaultAsync(Expression<Func<Product, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Product>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<Product> GetActives()
		{
			return _unitOfWork.GetRepository<Product>().GetActives();
		}

		public IQueryable<Product> GetAll()
		{
			return _unitOfWork.GetRepository<Product>().GetAll();
		}

		public IQueryable<Product> GetModifieds()
		{
			return _unitOfWork.GetRepository<Product>().GetModifieds();
		}

		public IQueryable<Product> GetPassives()
		{
			return _unitOfWork.GetRepository<Product>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<Product, X>> exp)
		{
			return _unitOfWork.GetRepository<Product>().Select(exp);
		}

		public async Task Update(Product item)
		{
			await _unitOfWork.GetRepository<Product>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<Product> list)
		{
			await _unitOfWork.GetRepository<Product>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<Product> Where(Expression<Func<Product, bool>> exp)
		{
			return _unitOfWork.GetRepository<Product>().Where(exp);
		}
	}
}
