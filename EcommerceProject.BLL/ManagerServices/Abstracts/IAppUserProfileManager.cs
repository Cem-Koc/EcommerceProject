using EcommerceProject.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.ManagerServices.Abstracts
{
    public interface IAppUserProfileManager
    {
		IQueryable<AppUserProfile> GetAll();
		IQueryable<AppUserProfile> GetActives();
		IQueryable<AppUserProfile> GetModifieds();
		IQueryable<AppUserProfile> GetPassives();

		//Modify Commands
		void Add(AppUserProfile item);
		Task AddAsync(AppUserProfile item);
		void AddRange(List<AppUserProfile> list);
		Task AddRangeAsync(List<AppUserProfile> list);
		Task Update(AppUserProfile item);
		Task UpdateRange(List<AppUserProfile> list);
		void Delete(AppUserProfile item);
		void DeleteRange(List<AppUserProfile> list);
		void Destroy(AppUserProfile item);
		void DestroyRange(List<AppUserProfile> list);

		//Linq Commands
		IQueryable<AppUserProfile> Where(Expression<Func<AppUserProfile, bool>> exp);
		Task<bool> AnyAsync(Expression<Func<AppUserProfile, bool>> exp);
		Task<AppUserProfile> FirstOrDefaultAsync(Expression<Func<AppUserProfile, bool>> exp);
		IQueryable<X> Select<X>(Expression<Func<AppUserProfile, X>> exp);

		//Find
		Task<AppUserProfile> FindAsync(int id);
	}
}
