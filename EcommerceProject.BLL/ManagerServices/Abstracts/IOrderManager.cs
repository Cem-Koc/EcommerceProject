using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IOrderManager
    {
        IQueryable<Order> GetAll();
		IQueryable<Order> GetActives();
		IQueryable<Order> GetModifieds();
		IQueryable<Order> GetPassives();

		//Modify Commands
		void Add(Order item);
		Task AddAsync(Order item);
		void AddRange(List<Order> list);
		Task AddRangeAsync(List<Order> list);
		Task Update(Order item);
		Task UpdateRange(List<Order> list);
		void Delete(Order item);
		void DeleteRange(List<Order> list);
		void Destroy(Order item);
		void DestroyRange(List<Order> list);

		//Linq Commands
		IQueryable<Order> Where(Expression<Func<Order, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<Order, bool>> exp);
		Task<Order> FirstOrDefaultAsync(Expression<Func<Order, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<Order, X>> exp);

		//Find
		Task<Order> FindAsync(int id);
	}
}
