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
            Save();
        }

        public virtual void InsertOrUpdate(TEntity entity)
        {
            if (entity.Id == 0)
            {
                Insert(entity);
            }
            else
            {
                Update(entity);
            }
        }

        public virtual void Delete(int id)
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
            Save();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            Save();
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}