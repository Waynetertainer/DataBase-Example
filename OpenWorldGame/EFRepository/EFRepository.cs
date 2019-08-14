using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EFRepository
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected Context ctx;

        public EFRepository(Context ctx)
        {
            this.ctx = ctx;
        }

        public TEntity Create(TEntity entity)
        {
            entity = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int id)
        {
            return ctx.Set<TEntity>().Find(id);
        }
    }
}
