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
            var groupPatients = Operations.CountGraph();
            foreach (var p in groupPatients)
            {
                this.chart1.Series[0].Points.AddXY(p.VDate, p.Count);
            }

            this.chart2.Series[0].Points.Clear();
            var groupCities = Operations.CountChart();
            foreach (var group in groupCities)
            {
                this.chart2.Series[0].Points.AddXY(group.City, group.Count);
            }

            this.chart3.Series[0].Points.Clear();
            var groupVaccines = Operations.CountPie();
            foreach(var group in groupVaccines)
            {
                this.chart3.Series[0].Points.AddXY(group.VaccineType, group.Count);
            }
        }
    }
}
