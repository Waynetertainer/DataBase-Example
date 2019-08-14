using System.Collections.Generic;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        TEntity GetByID(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Create(TEntity entity);
    }
}