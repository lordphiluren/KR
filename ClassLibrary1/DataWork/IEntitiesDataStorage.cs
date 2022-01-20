using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public interface IEntitiesDataStorage<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        List<TEntity> GetAll();
        bool Delete(TKey id);
    }
}