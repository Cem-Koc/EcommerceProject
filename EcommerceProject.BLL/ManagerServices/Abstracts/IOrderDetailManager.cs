using EcommerceProject.ENTITIES.Dtos.OrderDetails;
using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IOrderDetailManager
    {
		Task CreateOrderDetail(OrderDetailAddDto orderDetailAddDto);

		IQueryable<OrderDetail> GetAll();
		IQueryable<OrderDetail> GetActives();
		IQueryable<OrderDetail> GetModifieds();
		IQueryable<OrderDetail> GetPassives();

		//Modify Commands
		void Add(OrderDetail item);
		Task AddAsync(OrderDetail item);
		void AddRange(List<OrderDetail> list);
		Task AddRangeAsync(List<OrderDetail> list);
		Task Update(OrderDetail item);
		Task UpdateRange(List<OrderDetail> list);
		void Delete(OrderDetail item);
		void DeleteRange(List<OrderDetail> list);
		void Destroy(OrderDetail item);
		void DestroyRange(List<OrderDetail> list);

		//Linq Commands
		IQueryable<OrderDetail> Where(Expression<Func<OrderDetail, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<OrderDetail, bool>> exp);
		Task<OrderDetail> FirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<OrderDetail, X>> exp);

		//Find
		Task<OrderDetail> FindAsync(int id);
	}
}
