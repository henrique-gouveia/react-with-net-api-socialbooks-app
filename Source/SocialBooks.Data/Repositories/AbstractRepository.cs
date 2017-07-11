using System;
using System.Collections.Generic;
using System.Data.Entity;

using SocialBooks.Data.Context;
using SocialBooks.Models.Interfaces;
using System.Linq;

namespace SocialBooks.Data.Repositories
{
    public abstract class AbstractRepository<TEntity, TId> : IRepository<TEntity, TId>, IDisposable where TEntity : class
    {
        protected SocialBooksContext context = new SocialBooksContext();

        public TEntity FindOne(TId id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<TEntity> Query
        {
            get { return context.Set<TEntity>(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
