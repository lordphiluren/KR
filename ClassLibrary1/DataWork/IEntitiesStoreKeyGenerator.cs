using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public interface IEntitiesStoreKeyGenerator<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        List<TEntity> Entities { get; set; }
        TKey GenerateKey();
        TKey GetCurrentKey();
    }
}