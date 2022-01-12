using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank
{
    [Serializable]
    public class Vaccine
    {
        public string Type { get; set; }
        public int Amount { get; set; }
        public string VaccineInfo
        {
            get
            {
                return (Type + " Кол-во: " + Amount.ToString());
            }
        }
    }
}
