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
		private readonly MyContext _context;

		public UnitOfWork(MyContext context)
		{
			_context = context;
		}
		public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}

		public int Save()
		{
			return _context.SaveChanges();
		}

		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}

		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new BaseRepository<T>(_context);
		}
	}
}
