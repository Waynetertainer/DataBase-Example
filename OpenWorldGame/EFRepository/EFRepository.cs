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

        /// <summary>
        /// Creates a new Entity of a given type
        /// </summary>
        /// <param name="entity">The type of the Entity</param>
        /// <returns>
        /// The created Entity
        /// </returns>
        public TEntity Create(TEntity entity)
        {
            entity = ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();

            return entity;
        }

        /// <summary>
        /// Finds every Entity in the repository
        /// </summary>
        /// <returns>
        /// Every Entity in the repository
        /// </returns>
        public IEnumerable<TEntity> GetAll()
        {
            return ctx.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Finds the Entity with the given ID
        /// </summary>
        /// <param name="id">The ID of the Entity</param>
        /// <returns>
        /// The Entity with the given ID
        /// </returns>
        public TEntity GetByID(int id)
        {
            return ctx.Set<TEntity>().Find(id);
        }
    }
}
