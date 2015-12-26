using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using CommonInterface;
using Dal.Interface;

namespace DAL.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
        }


        public IEnumerable<TEntity> GetAll()
        {
            return _context?.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context?.Set<TEntity>().Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _context?.Set<TEntity>().FirstOrDefault(item => item.Id == id);
        }

        public void Delete(TEntity entity)
        {
            var delEntity = GetById(entity.Id);
            _context.Set<TEntity>().Remove(delEntity);
        }

        public void Create(TEntity entity)
        {
            var entry = _context.Entry(entity);
            _context.Set<TEntity>().Add(entry.Entity);
        }

        public void Update(TEntity entity)
        {
            var updateEntity = GetById(entity.Id);
            _context.Entry(updateEntity).CurrentValues.SetValues(entity);
        }
    }
}

