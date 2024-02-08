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
    public class CategoryManager : ICategoryManager
    {
		private readonly IUnitOfWork _unitOfWork;

		public CategoryManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
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