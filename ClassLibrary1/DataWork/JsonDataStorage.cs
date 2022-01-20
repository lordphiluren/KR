using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public class JsonDataStorage<TEntity>: IStorage<TEntity>
    {
        public virtual string Path { get; set; }
        protected virtual string DefaultName => $"{typeof(TEntity).Name}.json";
        protected virtual string AvailableName => Path ?? DefaultName;
        
        protected JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        public virtual TEntity Load()
        {
            string jsonString = File.ReadAllText(AvailableName);
            return JsonSerializer.Deserialize<TEntity>(jsonString, options);
        }
        
        public virtual void Save(TEntity data)
        {
            JsonSerializer.Serialize(data);
            File.WriteAllText(AvailableName, JsonSerializer.Serialize(data, options));
        }
    }
}
