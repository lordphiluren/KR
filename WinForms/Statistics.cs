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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            List<string> cities = Operations.AddCities();
            comboBox1.DataSource = cities;
            textBoxVaccinatedPeopleAmount.Text = Operations.CountPatientsRegion().ToString();
            textBoxVaccinatedMoreThanOnce.Text = Operations.CountMoreThanOnceVaccinedPatientsRegion().ToString();
            textBoxVaccinatedMinors.Text = Operations.CountMinorPatientsRegion().ToString();
            textBox1.Text = Operations.CountPatientsCity(comboBox1.Text).ToString();
            textBox2.Text = Operations.CountMoreThanOnceVaccinedPatientsCity(comboBox1.Text).ToString();
            textBox3.Text = Operations.CountMinorPatientsCity(comboBox1.Text).ToString();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Operations.CountPatientsCity(comboBox1.Text).ToString();
            textBox2.Text = Operations.CountMoreThanOnceVaccinedPatientsCity(comboBox1.Text).ToString();
            textBox3.Text = Operations.CountMinorPatientsCity(comboBox1.Text).ToString();
        }
    }
}
