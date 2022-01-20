using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VaccineBlank.DataWork
{
    [Serializable]
    public class Patient : IEntity<int>
    {
        public int PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime VaccineDate { get; set; }
        public string VaccineType { get; set; }
        public int VaccineDose { get; set; }
        public string CityOfVaccination { get; set; }
        public int Id { get; set; }

        [JsonIgnore]
        public string FullInfo
        {
            get
            {
                return (Surname + " " + Name + " " + Patronymic + " Дата рождения: " + BirthDate.ToString("dd.MM.yyyy") + " Дата последней вакцинации: " + VaccineDate.ToString("dd.MM.yyyy") + " " + VaccineType + " Доза вакцины: " + VaccineDose + " " + " Город вакцинации: " + CityOfVaccination);
            }
        }
        public int CompareTo(int other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(int other)
        {
            throw new NotImplementedException();
        }
    }
}