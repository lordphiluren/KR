using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VaccineBlank;
using System.Collections.Generic;
using System.Linq; 

namespace VaccineBlankTests
{
    [TestClass]
    public class PatientTest
    {
        static Patient patient1 = new Patient()
        {
            Surname = "а",
            Name = "а",
            Patronymic = "а",
            BirthDate = new DateTime (2007, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "lite",
            VaccineDose = 1,
            CityOfVaccination = "Мурманск"
        };
        static Patient patient2 = new Patient()
        {
            Surname = "б",
            Name = "б",
            Patronymic = "б",
            BirthDate = new DateTime(1999, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "v",
            VaccineDose = 2,
            CityOfVaccination = "Апатиты"
        };
        static Patient patient3 = new Patient()
        {
            Surname = "в",
            Name = "в",
            Patronymic = "в",
            BirthDate = new DateTime(2007, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "lite",
            VaccineDose = 1,
            CityOfVaccination = "Мончегорск"
        };
        static Patient patient4 = new Patient()
        {
            Surname = "г",
            Name = "г",
            Patronymic = "г",
            BirthDate = new DateTime(2009, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "v",
            VaccineDose = 2,
            CityOfVaccination = "Мурманск"
        };
        static Patient patient5 = new Patient()
        {
            Surname = "д",
            Name = "д",
            Patronymic = "д",
            BirthDate = new DateTime(1999, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "lite",
            VaccineDose = 1,
            CityOfVaccination = "Кандалакша"
        };
        static Patient patient6 = new Patient()
        {
            Surname = "е",
            Name = "е",
            Patronymic = "е",
            BirthDate = new DateTime(2008, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "v",
            VaccineDose = 2,
            CityOfVaccination = "Мурманск"
        };
        static Patient patient7 = new Patient()
        {
            Surname = "ж",
            Name = "ж",
            Patronymic = "ж",
            BirthDate = new DateTime(1999, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "lite",
            VaccineDose = 1,
            CityOfVaccination = "Апатиты"
        };
        static Patient patient8 = new Patient()
        {
            Surname = "з",
            Name = "з",
            Patronymic = "з",
            BirthDate = new DateTime(2011, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "v",
            VaccineDose = 2,
            CityOfVaccination = "Мурманск"
        };
        static Patient patient9 = new Patient()
        {
            Surname = "и",
            Name = "и",
            Patronymic = "и",
            BirthDate = new DateTime(1999, 1, 1),
            VaccineDate = new DateTime(2022, 1, 12),
            VaccineType = "lite",
            VaccineDose = 1,
            CityOfVaccination = "Оленегорск"
        };
        List<Patient> patients = new List<Patient>() { patient1, patient2, patient3, patient4, patient5, patient6, patient7, patient8, patient9 };
        List<string> cities = new List<string>() { "Мурманск", "Оленегорск", "Мончегорск", "Апатиты", "Кировск", "Кандалакша" };
        
        [TestMethod]
        public void TestCountPatientsRegion()
        {
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string actual = Operations.CountPatientsRegion();
            string expected = "9";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountPatientsCity()
        {
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string city = "Мурманск";
            string actual = Operations.CountPatientsCity(city);
            string expected = "4";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountMoreThanOnceVaccinedPatientsRegion()
        {
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string actual = Operations.CountMoreThanOnceVaccinedPatientsRegion();
            string expected = "4";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountMoreThanOnceVaccinedPatientsCity()
        {
            string city = "Мурманск";
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string actual = Operations.CountMoreThanOnceVaccinedPatientsCity(city);
            string expected = "3";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountMinorPatientsRegion()
        {
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string actual = Operations.CountMinorPatientsRegion();
            string expected = "5";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCountMinorPatientsCity()
        {
            string city = "Мончегорск";
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string actual = Operations.CountMinorPatientsCity(city);
            string expected = "1";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestCreateSortByCityPatientList()
        {
            FileOperations.WriteFile(patients, FileOperations.PathPatient);
            string city = "Мурманск";
            List<Patient> actual = Operations.CreateSortByCityPatientList(city);
            List<Patient> expected = new List<Patient>() { patient1, patient4, patient6, patient8 };
            Assert.AreEqual(expected.Count, actual.Count);
        }
    }
}
