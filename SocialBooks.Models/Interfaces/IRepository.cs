using System.Collections.Generic;

namespace SocialBooks.Models.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        TEntity FindOne(TId id);

        IEnumerable<TEntity> FindAll();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Dispose();
    }
}
