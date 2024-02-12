using EcommerceProject.DAL.Context;
using EcommerceProject.DAL.Repositories.Abstracts;
using EcommerceProject.ENTITIES.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly MyContext _context;
        public BaseRepository(MyContext context)
        {
			_context = context;
        }

        private DbSet<T> Table { get =>_context.Set<T>(); }

        public void Add(T item)
        {
			Table.Add(item);
        }

        public async Task AddAsync(T item)
        {
            await Table.AddAsync(item);
        }

        public void AddRange(List<T> list)
        {
			Table.AddRange();
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await Table.AddRangeAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await Table.AnyAsync(exp);
        }

        /// <summary>
        /// Verinin pasife çekilmesidir.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
        }

		public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
			Table.Remove(item);
        }

        public void DestroyRange(List<T> list)
        {
			Table.RemoveRange(list);
        }

        public async Task<T> FindAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await Table.FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
            return Where(x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);

            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);

            return await query.SingleAsync();
        }

        public IQueryable<T> GetModifieds()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated);
        }

        public IQueryable<T> GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return Table.Select(exp);
        }

        public async Task Update(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            T original = await FindAsync(item.ID);
			Table.Entry(original).CurrentValues.SetValues(item);
        }

        public async Task UpdateRange(List<T> items)
        {
            foreach (T item in items) await Update(item);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return Table.Where(exp);
        }
    }
}
