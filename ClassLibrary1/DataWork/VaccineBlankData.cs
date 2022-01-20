using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    public class VaccineBlankData
    {
        public static EntitiesDataStorage<Patient, int> Patients { get; }
        public static EntitiesDataStorage<Vaccine, int> Vaccines { get; }
        
        static VaccineBlankData()
        {
            Patients = new EntitiesDataStorage<Patient, int>(new IntegerEntitiesStoreKeyGenerator<Patient>());
            Vaccines = new EntitiesDataStorage<Vaccine, int>(new IntegerEntitiesStoreKeyGenerator<Vaccine>());
        }
    }
}
