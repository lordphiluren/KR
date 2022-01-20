using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace VaccineBlank
{
    public class Operations
    {
        public static List<string> AddCities()
        {
            List<string> cities = new List<string>() { "Мурманск", "Оленегорск", "Мончегорск", "Апатиты", "Кировск", "Кандалакша" };
            return cities;
        }
        
        public static string CountPatientsRegion()
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            string count = patients.Count().ToString();
            return count;
            
        }
        public static string CountPatientsCity(string city)
        {

            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = from patient in patients
                              where patient.CityOfVaccination == city
                              select patient;
            string count = tempPatient.ToList().Count().ToString();
            return count;

        }
        public static string CountMoreThanOnceVaccinedPatientsRegion()
        {

            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = from patient in patients
                              where patient.VaccineDose > 1
                              select patient;
            string count = tempPatient.ToList().Count().ToString();
            return count;
        }
        public static string CountMoreThanOnceVaccinedPatientsCity(string city)
        {

            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = from patient in patients
                              where patient.VaccineDose > 1 && patient.CityOfVaccination == city
                              select patient;
            string count = tempPatient.ToList().Count().ToString();
            return count;
        }
        public static string CountMinorPatientsRegion()
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = from patient in patients
                              where patient.BirthDate.AddYears(18) > patient.VaccineDate
                              select patient;
            string count = tempPatient.ToList().Count().ToString();
            return count;

        }
        public static string CountMinorPatientsCity(string city)
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = from patient in patients
                              where patient.BirthDate.AddYears(18) > patient.VaccineDate && patient.CityOfVaccination == city
                              select patient;
            string count = tempPatient.ToList().Count().ToString();
            return count;

        }
        public static List<Patient> CreateSortByCityPatientList(string city)
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var sortPatient = patients.Where(p => p.CityOfVaccination == city)
                                      .OrderBy(p => p.VaccineDate)
                                      .ToList();
            return sortPatient;
        }
        public static IEnumerable<(DateTime VDate, int Count)> CountGraph()
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = patients.GroupBy(p => p.VaccineDate.Date)
                            .Select(g => (VDate : g.Key, Count : g.Count()));
            return tempPatient;
        }
        public static IEnumerable<(string City, int Count)> CountChart()
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = patients.GroupBy(p => p.CityOfVaccination)
                            .Select(g => (City: g.Key, Count: g.Count()));
            return tempPatient;
        }
        public static IEnumerable<(string VaccineType, int Count)> CountPie()
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            var tempPatient = patients.GroupBy(p => p.VaccineType)
                            .Select(g => (VaccineType: g.Key, Count: g.Count()));
            return tempPatient;
        }

    }
}
