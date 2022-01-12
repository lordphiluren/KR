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
            string[] cities = Operations.AddCities();
            comboBox1.DataSource = cities;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Patient> patients = new List<Patient>();
            patients = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            
            this.chart1.Series[0].Points.Clear();
            var groupPatients = patients.GroupBy(p => p.VaccineDate)
                                        .Select(g => new { Date = g.Key, Count = g.Count() });
            foreach(var group in groupPatients)
            {
                    this.chart1.Series[0].Points.AddXY(group.Date, group.Count);
            }

            /////////////////////////////////////
            this.chart2.Series[0].Points.Clear();
            var groupCities = patients.GroupBy(p => p.CityOfVaccination)
                                        .Select(g => new { City = g.Key, Count = g.Count() });
            foreach(var group in groupCities)
            {
                this.chart2.Series[0].Points.AddXY(group.City, group.Count);
            }
            /////////////////////////////////////
            this.chart3.Series[0].Points.Clear();
            var groupVaccines = patients.GroupBy(p => p.VaccineType)
                                        .Select(g => new { VaccineType = g.Key, Count = g.Count() });
            foreach(var group in groupVaccines)
            {
                this.chart3.Series[0].Points.AddXY(group.VaccineType, group.Count);
            }
        }
    }
}
