using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VaccineBlank;

namespace WinForms
{
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);

            // Данные для диграмм подготавливаются либо в отдельном классе либо в FileOperations
            var groupPatients = patients.GroupBy(p => p.VaccineDate.Date)
                            .Select(g => new { VDate = g.Key, Count = g.Count() });
            foreach (var group in groupPatients)
            {
                this.chart1.Series[0].Points.AddXY(group.VDate, group.Count);
            }

            this.chart2.Series[0].Points.Clear();
            // Данные для диграмм подготавливаются либо в отдельном классе либо в FileOperations
            var groupCities = patients.GroupBy(p => p.CityOfVaccination)
                                        .Select(g => new { City = g.Key, Count = g.Count() });
            foreach(var group in groupCities)
            {
                this.chart2.Series[0].Points.AddXY(group.City, group.Count);
            }

            this.chart3.Series[0].Points.Clear();
            // Данные для диграмм подготавливаются либо в отдельном классе либо в FileOperations
            var groupVaccines = patients.GroupBy(p => p.VaccineType)
                                        .Select(g => new { VaccineType = g.Key, Count = g.Count() });
            foreach(var group in groupVaccines)
            {
                this.chart3.Series[0].Points.AddXY(group.VaccineType, group.Count);
            }

            // А если тебя смущают анонимные типы, то во превых можно деанонимизировать, во вторых словарь, в третьих кортеж
        }
    }
}
