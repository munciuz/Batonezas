using System.Linq;
using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface ISRepository<TEntity> where TEntity : class, ISBatonezasEntity, new()
    {
        TEntity Get(string id);
        IQueryable<TEntity> CreateQuery();
        void Insert(TEntity entity);
        void Delete(string id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}