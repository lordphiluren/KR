using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public class IntegerEntitiesStoreKeyGenerator<TEntity> : IEntitiesStoreKeyGenerator<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        public List<TEntity> Entities { get; set; }
        public int GenerateKey()
        {
            return GetCurrentKey() + 1;
        }
        public int GetCurrentKey()
        {
            var entityWithMaxId = Entities?.OrderByDescending(e => e.Id).FirstOrDefault();
            if (entityWithMaxId == null)
            {
                return 0;
            }
            return entityWithMaxId.Id;
        }
    }
}