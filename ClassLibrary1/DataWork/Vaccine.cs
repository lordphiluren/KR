using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace VaccineBlank.DataWork
{
    [Serializable]
    public class Vaccine : IEntity<int>
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public int Id { get; set; }
        [JsonIgnore]
        public string VaccineInfo
        {
            get
            {
                return (Type + " Кол-во: " + Amount.ToString());
            }
        }
    }
}