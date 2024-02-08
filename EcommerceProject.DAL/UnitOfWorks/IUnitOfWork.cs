using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IEntity, new();
		Task<int> SaveAsync();
		int Save();
	}
}
