using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AcquisitionPlus.Business.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveAll(IEnumerable<TEntity> entities);
    }
}
