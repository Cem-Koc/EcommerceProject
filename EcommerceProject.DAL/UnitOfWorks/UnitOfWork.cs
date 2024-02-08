using EcommerceProject.DAL.Context;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.DAL.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly MyContext _db;

		public UnitOfWork(MyContext db)
		{
			_db = db;
		}
		public async ValueTask DisposeAsync()
		{
			await _db.DisposeAsync();
		}

		public int Save()
		{
			return _db.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await _db.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new BaseRepository<T>(_db);
		}
	}
}
