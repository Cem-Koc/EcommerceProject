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
    public class OrderDetailManager : IOrderDetailManager
    {
		private readonly IUnitOfWork _unitOfWork;

		public OrderDetailManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Add(OrderDetail item)
		{
			_unitOfWork.GetRepository<OrderDetail>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(OrderDetail item)
		{
			await _unitOfWork.GetRepository<OrderDetail>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<OrderDetail> list)
		{
			_unitOfWork.GetRepository<OrderDetail>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<OrderDetail> list)
		{
			await _unitOfWork.GetRepository<OrderDetail>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<OrderDetail, bool>> exp)
		{
			return await _unitOfWork.GetRepository<OrderDetail>().AnyAsync(exp);
		}

		public void Delete(OrderDetail item)
		{
			_unitOfWork.GetRepository<OrderDetail>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<OrderDetail> list)
		{
			_unitOfWork.GetRepository<OrderDetail>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(OrderDetail item)
		{
			_unitOfWork.GetRepository<OrderDetail>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<OrderDetail> list)
		{
			_unitOfWork.GetRepository<OrderDetail>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<OrderDetail> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<OrderDetail>().FindAsync(id);
		}

		public async Task<OrderDetail> FirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> exp)
		{
			return await _unitOfWork.GetRepository<OrderDetail>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<OrderDetail> GetActives()
		{
			return _unitOfWork.GetRepository<OrderDetail>().GetActives();
		}

		public IQueryable<OrderDetail> GetAll()
		{
			return _unitOfWork.GetRepository<OrderDetail>().GetAll();
		}

		public IQueryable<OrderDetail> GetModifieds()
		{
			return _unitOfWork.GetRepository<OrderDetail>().GetModifieds();
		}

		public IQueryable<OrderDetail> GetPassives()
		{
			return _unitOfWork.GetRepository<OrderDetail>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<OrderDetail, X>> exp)
		{
			return _unitOfWork.GetRepository<OrderDetail>().Select(exp);
		}

		public async Task Update(OrderDetail item)
		{
			await _unitOfWork.GetRepository<OrderDetail>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<OrderDetail> list)
		{
			await _unitOfWork.GetRepository<OrderDetail>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<OrderDetail> Where(Expression<Func<OrderDetail, bool>> exp)
		{
			return _unitOfWork.GetRepository<OrderDetail>().Where(exp);
		}
	}
}
