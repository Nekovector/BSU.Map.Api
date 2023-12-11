using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BSU.Map.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);

        void AddRange(IEnumerable<T> items);

        void Delete(T item);

        void Delete(IEnumerable<T> items);

        void Update(T item);

        T GetById(int id);

        IQueryable<T> GetAll();

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);

        T Get(Expression<Func<T, bool>> predicate);
    }
}
