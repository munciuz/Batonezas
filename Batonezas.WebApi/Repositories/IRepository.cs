using System.Linq;
using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IBatonezasEntity, new()
    {
        TEntity Get(int id);
        IQueryable<TEntity> CreateQuery();
        void Insert(TEntity entity);
        void Delete(string id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void Save();
    }
}