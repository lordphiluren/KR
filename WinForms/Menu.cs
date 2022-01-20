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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace WinForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            dateTimePickerBDAY.Format = DateTimePickerFormat.Custom;
            dateTimeVaccineDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerBDAY.CustomFormat = "dd, MM, yyyy";
            dateTimeVaccineDate.CustomFormat = "dd, MM, yyyy";
            if (File.Exists(FileOperations.PathStorage))
            {
                List<Vaccine> vaccine = new List<Vaccine>();
                vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
                comboBoxVaccineType.DataSource = vaccine;
                comboBoxVaccineType.DisplayMember = "Type";
                comboBoxVaccineType.ValueMember = "Type";
            }
            List<string> cities = Operations.AddCities();
            comboBoxCOV.DataSource = cities;


        }
        private void Menu_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Statistics newForm = new Statistics();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Table newForm = new Table();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphs newForm = new Graphs();
            newForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxPSeries.Text.Length != 0 && textBoxPNum.Text.Length != 0 && textBoxName.Text.Length != 0 && textBoxSurname.Text.Length != 0 && comboBoxCOV.SelectedItem != null && comboBoxVaccineType.SelectedItem != null)
            {
                try
                {
                    try { FileOperations.RemoveVaccine(comboBoxVaccineType.Text); } catch { throw; }
                    FileOperations.WriteFile(FileOperations.AddPatient(FileOperations.ReadFile<Patient>(FileOperations.PathPatient), textBoxPSeries.Text,
                    textBoxPNum.Text,
                    textBoxSurname.Text,
                    textBoxName.Text,
                    textBoxPatronymic.Text,
                    dateTimePickerBDAY.Value,
                    dateTimeVaccineDate.Value,
                    comboBoxVaccineType.Text,
                    comboBoxCOV.Text), FileOperations.PathPatient);

                    textBoxPSeries.Clear();
                    textBoxPNum.Clear();
                    textBoxSurname.Clear();
                    textBoxName.Clear();
                    textBoxPatronymic.Clear();
                    dateTimePickerBDAY.Value = dateTimePickerBDAY.MinDate;
                    comboBoxVaccineType.ResetText();
                }
                catch { MessageBox.Show("Вакцины нет в наличии", "Ошибка", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("Заполните форму","Ошибка",MessageBoxButtons.OK); }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Graphs newForm = new Graphs();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Storage newForm = new Storage();
            newForm.Show();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOperations.DeleteFile(FileOperations.PathPatient);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientEditForm newForm = new PatientEditForm();
            newForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBoxVaccineType.DataSource = null;
            List<Vaccine> vaccine = new List<Vaccine>();
            vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
            comboBoxVaccineType.DataSource = vaccine;
            comboBoxVaccineType.DisplayMember = "Type";
            comboBoxVaccineType.ValueMember = "Type";

        }
    }
}
