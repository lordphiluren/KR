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
            // https://www.youtube.com/watch?v=6pLWKrcoJl4
            //var tempPatient = from patient in patients
            //                  where patient.CityOfVaccination == city
            //                  select patient;
            //patients = tempPatient.ToList();
            //var sortPatient = from patient in patients
            //                  orderby patient.VaccineDate
            //                  select patient;

            var result = patients.Where(p => p.CityOfVaccination == city)
                .OrderBy(p => p.VaccineDate)
                .ToList();
            // The same as reult but another way
            var result2 = from patient in patients
                         where patient.CityOfVaccination == city
                         orderby patient.VaccineDate
                         select patient;

            return result.ToList();
        }

    }
}
