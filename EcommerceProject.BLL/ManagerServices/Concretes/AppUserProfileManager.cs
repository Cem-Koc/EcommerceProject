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
    public class AppUserProfileManager : IAppUserProfileManager
    {
		private readonly IUnitOfWork _unitOfWork;

		public AppUserProfileManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Add(AppUserProfile item)
		{
			_unitOfWork.GetRepository<AppUserProfile>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(AppUserProfile item)
		{
			await _unitOfWork.GetRepository<AppUserProfile>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<AppUserProfile> list)
		{
			_unitOfWork.GetRepository<AppUserProfile>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<AppUserProfile> list)
		{
			await _unitOfWork.GetRepository<AppUserProfile>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<AppUserProfile, bool>> exp)
		{
			return await _unitOfWork.GetRepository<AppUserProfile>().AnyAsync(exp);
		}

		public void Delete(AppUserProfile item)
		{
			_unitOfWork.GetRepository<AppUserProfile>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<AppUserProfile> list)
		{
			_unitOfWork.GetRepository<AppUserProfile>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(AppUserProfile item)
		{
			_unitOfWork.GetRepository<AppUserProfile>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<AppUserProfile> list)
		{
			_unitOfWork.GetRepository<AppUserProfile>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<AppUserProfile> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<AppUserProfile>().FindAsync(id);
		}

		public async Task<AppUserProfile> FirstOrDefaultAsync(Expression<Func<AppUserProfile, bool>> exp)
		{
			return await _unitOfWork.GetRepository<AppUserProfile>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<AppUserProfile> GetActives()
		{
			return _unitOfWork.GetRepository<AppUserProfile>().GetActives();
		}

		public IQueryable<AppUserProfile> GetAll()
		{
			return _unitOfWork.GetRepository<AppUserProfile>().GetAll();
		}

		public IQueryable<AppUserProfile> GetModifieds()
		{
			return _unitOfWork.GetRepository<AppUserProfile>().GetModifieds();
		}

		public IQueryable<AppUserProfile> GetPassives()
		{
			return _unitOfWork.GetRepository<AppUserProfile>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<AppUserProfile, X>> exp)
		{
			return _unitOfWork.GetRepository<AppUserProfile>().Select(exp);
		}

		public async Task Update(AppUserProfile item)
		{
			await _unitOfWork.GetRepository<AppUserProfile>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<AppUserProfile> list)
		{
			await _unitOfWork.GetRepository<AppUserProfile>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<AppUserProfile> Where(Expression<Func<AppUserProfile, bool>> exp)
		{
			return _unitOfWork.GetRepository<AppUserProfile>().Where(exp);
		}
	}
}
