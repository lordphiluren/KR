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
            this.chart1.Series[0].Points.Clear(); 
            List<Patient> patients = new List<Patient>();
            FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            for (DateTime d = new DateTime(2022, 01, 01); d <= DateTime.Now; d.AddDays(1))
            {
                var count = patients.Count(x => x.VaccineDate == d && x.CityOfVaccination == comboBox1.Text);
                this.chart1.Series[0].Points.AddXY(d, count);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
