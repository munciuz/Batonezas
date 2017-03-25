using System.Data.Entity;
using System.Linq;
using Batonezas.DataAccess;

namespace Batonezas.WebApi.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IBatonezasEntity, new()
    {
        private BatonezasContext context;
        private DbSet<TEntity> dbSet;

        public Repository()
        {
            context = new BatonezasContext();
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> CreateQuery()
        {
            return dbSet;
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(string id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}