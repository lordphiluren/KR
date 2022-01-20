using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public class EntitiesDataStorage<TEntity, TKey> : JsonDataStorage<List<TEntity>>, IEntitiesDataStorage<TEntity,TKey>
        where TEntity: class, IEntity<TKey>
        where TKey : IEquatable<TKey>, IComparable<TKey>
    {
        public IEntitiesStoreKeyGenerator<TEntity, TKey> KeyGenerator { get; }
        public TKey MaxId => KeyGenerator.GetCurrentKey();
        protected override string DefaultName => $"{typeof(TEntity).Name}s.json";

        public EntitiesDataStorage(IEntitiesStoreKeyGenerator<TEntity, TKey> keyGenerator)
        {
            KeyGenerator = keyGenerator;
            if (!File.Exists(AvailableName))
            {
                Save(new List<TEntity>());
            }
            KeyGenerator.Entities = Load();
        }
        public override List<TEntity> Load()
        {
            var data = base.Load();
            KeyGenerator.Entities = data;
            return data;
        }
        public TEntity Add(TEntity entity)
        {
            entity.Id = KeyGenerator.GenerateKey();
            var data = Load();
            data.Add(entity);
            Save(data);
            return entity;
        }
        public TEntity Update(TEntity entity)
        {
            var data = Load();
            var existingEntityData = data.Where(e => e.Id.Equals(entity.Id))
                .Select((e, index) => new { Entity = e, Index = index })
                .FirstOrDefault();
            if (existingEntityData == null)
            {
                return null;
            }
            data[existingEntityData.Index] = existingEntityData.Entity;
            Save(data);
            return entity;
        }
        public List<TEntity> GetAll()
        {
            return Load();
        }
        public bool Delete(TKey id)
        {
            var data = Load();
            var existingEntityData = data.FirstOrDefault(e => e.Id.Equals(id));
            if (existingEntityData == null)
            {
                return false;
            }
            var newData = data.Where(e => !e.Id.Equals(id))
                .ToList();
            Save(newData);
            return true;
        }
    }
}
