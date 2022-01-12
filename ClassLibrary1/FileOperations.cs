using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.ComponentModel;

namespace VaccineBlank
{
    public class FileOperations
    {
        public static string PathPatient
        {
            get
            {
                return (@"Patient.json");
            }
        }
        public static string PathStorage
        {
            get
            {
                return (@"Storage.json");
            }
        }

        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        public static string Serializer<T>(List<T> list)     
        {
            return JsonSerializer.Serialize(list, options);
        }
        public static List<T> Deserializer<T>(string path)            
        {
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(jsonString);
        }
        public static List<T> ReadFile<T>(string path)
        {
            List<T> list = new List<T>();
            if (File.Exists(path))
            {
                list = Deserializer<T>(path);
            }
            return list;
        }
        public static void WriteFile<T>(List<T> list, string path)
        {
            File.WriteAllText(path, Serializer(list));
        }
        public static List<Patient> AddPatient(List<Patient> list,
            string tbPSeries,
            string tbPNum,
            string tbSurname,
            string tbName,
            string tbPatronymic,
            DateTime dtpBdate,
            DateTime dtpVdate,
            string tbVtype,
            string tbCityOfVac)
        {
            string pinfo = tbPSeries + tbPNum;
            int index = list.FindIndex(x => x.PassportInfo == pinfo);
            if (index >= 0)
            {
                list[index].VaccineDose += 1;
                list[index].CityOfVaccination = tbCityOfVac;
            }
            else
            {
                list.Add(new Patient()
                {
                    PassportSeries = int.Parse(tbPSeries),
                    PassportNumber = int.Parse(tbPNum),
                    Surname = tbSurname,
                    Name = tbName,
                    Patronymic = tbPatronymic,
                    BirthDate = dtpBdate,
                    VaccineDate = dtpVdate,
                    VaccineType = tbVtype,
                    CityOfVaccination = tbCityOfVac,
                    VaccineDose = 1
                });
            }
            return list;
        }
        public static List<Vaccine> AddVaccine(List<Vaccine> list, string tbType, decimal numVacAmount)
        {
            int index = list.FindIndex(x => x.Type.ToUpper() == tbType.ToUpper());
            if (index >= 0)
            {
                list[index].Amount += Convert.ToInt32(numVacAmount);
            }
            else
            {
                list.Add(new Vaccine()
                {
                    Type = tbType,
                    Amount = Convert.ToInt32(numVacAmount)
                });
            }
            return list;
        }
        public static void RemoveVaccine(string cbType)
        {
            List<Vaccine> vaccine = new List<Vaccine>();
            vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
            int index = vaccine.FindIndex(x => x.Type == cbType);
            vaccine[index].Amount -= 1;
            vaccine.RemoveAll(x => x.Amount < 1);
            File.WriteAllText(PathStorage, Serializer<Vaccine>(vaccine));
        }
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

    }
} 
