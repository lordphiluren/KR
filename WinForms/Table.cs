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
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
            List<string> cities = Operations.AddCities();
            comboBoxCities.DataSource = cities;
            dataGridView1.DataSource = Operations.CreateSortByCityPatientList(comboBoxCities.Text);
            dataGridView1.Columns["PassportSeries"].Visible = false;
            dataGridView1.Columns["PassportNumber"].Visible = false;
            dataGridView1.Columns["FullInfo"].Visible = false;
            dataGridView1.Columns["PassportInfo"].Visible = false;
        }

        private void comboBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Operations.CreateSortByCityPatientList(comboBoxCities.Text);
            dataGridView1.Columns["PassportSeries"].Visible = false;
            dataGridView1.Columns["PassportNumber"].Visible = false;
            dataGridView1.Columns["FullInfo"].Visible = false;
            dataGridView1.Columns["PassportInfo"].Visible = false;
        }
    }
}
