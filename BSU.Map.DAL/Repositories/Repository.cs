using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BSU.Map.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BSU.Map.DAL.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        protected bsu_mapContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository(bsu_mapContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        public void Add(T item)
        {
            DbSet.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            DbSet.AddRange(items);
        }

        public void Delete(T item)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(item);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void Delete(IEnumerable<T> items)
        {
            DbSet.RemoveRange(items);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Update(T item)
        {
            EntityEntry dbEntityEntry = DbContext.Entry(item);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
