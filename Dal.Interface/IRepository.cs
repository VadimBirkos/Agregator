using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CommonInterface;

namespace Dal.Interface
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        void Delete(TEntity entity);
        void Create(TEntity entity);
        void Update(TEntity entity);
    }
}