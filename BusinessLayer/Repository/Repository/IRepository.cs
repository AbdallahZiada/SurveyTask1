using System;
using System.Collections.Generic;

namespace BusinessLayer.Repository.Repository
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T FirstOrDefault(Func<T, bool> predicate);
        T FirstOrDefault();
        T Find(int id);
        IEnumerable<T> All();
    }
}
