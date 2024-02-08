using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IAppUserManager
    {
        Task<bool> CreateUserAsync(AppUser item);

        IQueryable<AppUser> GetAll();
		IQueryable<AppUser> GetActives();
		IQueryable<AppUser> GetModifieds();
		IQueryable<AppUser> GetPassives();

		//Modify Commands
		void Add(AppUser item);
		Task AddAsync(AppUser item);
		void AddRange(List<AppUser> list);
		Task AddRangeAsync(List<AppUser> list);
		Task Update(AppUser item);
		Task UpdateRange(List<AppUser> list);
		void Delete(AppUser item);
		void DeleteRange(List<AppUser> list);
		void Destroy(AppUser item);
		void DestroyRange(List<AppUser> list);

		//Linq Commands
		IQueryable<AppUser> Where(Expression<Func<AppUser, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<AppUser, bool>> exp);
		Task<AppUser> FirstOrDefaultAsync(Expression<Func<AppUser, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<AppUser, X>> exp);

		//Find
		Task<AppUser> FindAsync(int id);
	}
}
