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
	public class AppUserManager : IAppUserManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IAppUserRepository _userRepository;

		public AppUserManager(IUnitOfWork unitOfWork,IAppUserRepository userRepository)
		{
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
		}

		public void Add(AppUser item)
		{
			_unitOfWork.GetRepository<AppUser>().Add(item);
			_unitOfWork.Save();
		}

		public async Task AddAsync(AppUser item)
		{
			await _unitOfWork.GetRepository<AppUser>().AddAsync(item);
			await _unitOfWork.SaveAsync();
		}

		public void AddRange(List<AppUser> list)
		{
			_unitOfWork.GetRepository<AppUser>().AddRange(list);
			_unitOfWork.Save();
		}

		public async Task AddRangeAsync(List<AppUser> list)
		{
			await _unitOfWork.GetRepository<AppUser>().AddRangeAsync(list);
			await _unitOfWork.SaveAsync();
		}

		public async Task<bool> AnyAsync(Expression<Func<AppUser, bool>> exp)
		{
			return await _unitOfWork.GetRepository<AppUser>().AnyAsync(exp);
		}

		public void Delete(AppUser item)
		{
			_unitOfWork.GetRepository<AppUser>().Delete(item);
			_unitOfWork.Save();
		}

		public void DeleteRange(List<AppUser> list)
		{
			_unitOfWork.GetRepository<AppUser>().DeleteRange(list);
			_unitOfWork.Save();
		}

		public void Destroy(AppUser item)
		{
			_unitOfWork.GetRepository<AppUser>().Destroy(item);
			_unitOfWork.Save();
		}

		public void DestroyRange(List<AppUser> list)
		{
			_unitOfWork.GetRepository<AppUser>().DestroyRange(list);
			_unitOfWork.Save();
		}

		public async Task<AppUser> FindAsync(int id)
		{
			return await _unitOfWork.GetRepository<AppUser>().FindAsync(id);
		}

		public async Task<AppUser> FirstOrDefaultAsync(Expression<Func<AppUser, bool>> exp)
		{
			return await _unitOfWork.GetRepository<AppUser>().FirstOrDefaultAsync(exp);
		}

		public IQueryable<AppUser> GetActives()
		{
			return _unitOfWork.GetRepository<AppUser>().GetActives();
		}

		public IQueryable<AppUser> GetAll()
		{
			return _unitOfWork.GetRepository<AppUser>().GetAll();
		}

		public IQueryable<AppUser> GetModifieds()
		{
			return _unitOfWork.GetRepository<AppUser>().GetModifieds();
		}

		public IQueryable<AppUser> GetPassives()
		{
			return _unitOfWork.GetRepository<AppUser>().GetPassives();
		}

		public IQueryable<X> Select<X>(Expression<Func<AppUser, X>> exp)
		{
			return _unitOfWork.GetRepository<AppUser>().Select(exp);
		}

		public async Task Update(AppUser item)
		{
			await _unitOfWork.GetRepository<AppUser>().Update(item);
			await _unitOfWork.SaveAsync();
		}

		public async Task UpdateRange(List<AppUser> list)
		{
			await _unitOfWork.GetRepository<AppUser>().UpdateRange(list);
			await _unitOfWork.SaveAsync();
		}

		public IQueryable<AppUser> Where(Expression<Func<AppUser, bool>> exp)
		{
			return _unitOfWork.GetRepository<AppUser>().Where(exp);
		}

		public async Task<bool> CreateUserAsync(AppUser item)
		{
			var result = await _userRepository.AddUser(item);
			await _unitOfWork.SaveAsync();
			return result;
		}
	}
}
