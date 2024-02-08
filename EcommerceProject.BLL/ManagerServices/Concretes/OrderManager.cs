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
    public class OrderManager : IOrderManager
    {
		private readonly IUnitOfWork _unitOfWork;

		public OrderManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Add(Order item)
		{
			_unitOfWork.GetRepository<Order>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(Order item)
		{
			await _unitOfWork.GetRepository<Order>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<Order> list)
		{
			_unitOfWork.GetRepository<Order>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<Order> list)
		{
			await _unitOfWork.GetRepository<Order>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<Order, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Order>().AnyAsync(exp);
		}

		public void Delete(Order item)
		{
			_unitOfWork.GetRepository<Order>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<Order> list)
		{
			_unitOfWork.GetRepository<Order>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(Order item)
		{
			_unitOfWork.GetRepository<Order>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<Order> list)
		{
			_unitOfWork.GetRepository<Order>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<Order> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<Order>().FindAsync(id);
		}

		public async Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> exp)
		{
			return await _unitOfWork.GetRepository<Order>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<Order> GetActives()
		{
			return _unitOfWork.GetRepository<Order>().GetActives();
		}

		public IQueryable<Order> GetAll()
		{
			return _unitOfWork.GetRepository<Order>().GetAll();
		}

		public IQueryable<Order> GetModifieds()
		{
			return _unitOfWork.GetRepository<Order>().GetModifieds();
		}

		public IQueryable<Order> GetPassives()
		{
			return _unitOfWork.GetRepository<Order>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<Order, X>> exp)
		{
			return _unitOfWork.GetRepository<Order>().Select(exp);
		}

		public async Task Update(Order item)
		{
			await _unitOfWork.GetRepository<Order>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<Order> list)
		{
			await _unitOfWork.GetRepository<Order>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<Order> Where(Expression<Func<Order, bool>> exp)
		{
			return _unitOfWork.GetRepository<Order>().Where(exp);
		}
	}
}
