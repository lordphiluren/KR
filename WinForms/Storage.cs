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
using System.IO;

namespace WinForms
{
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
            if (File.Exists(FileOperations.PathStorage))
            {
                List<Vaccine> vaccine = new List<Vaccine>();
                vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
                listBoxStorage.DataSource = vaccine;
                listBoxStorage.DisplayMember = "VaccineInfo";
                listBoxStorage.ValueMember = "Type";
                
            }
        }
        private void buttonAddVaccine_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                FileOperations.WriteFile(FileOperations.AddVaccine(FileOperations.ReadFile<Vaccine>(FileOperations.PathStorage),
                   textBox1.Text, (int)numUpDownVaccineAmount.Value), FileOperations.PathStorage);
                List<Vaccine> vaccine = new List<Vaccine>();
                vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
                listBoxStorage.DataSource = vaccine;
                listBoxStorage.DisplayMember = "VaccineInfo";
                listBoxStorage.ValueMember = "Type";
            }
            else { MessageBox.Show("Введите название вакцины", "Ошибка", MessageBoxButtons.OK); }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            List<Vaccine> vaccine = new List<Vaccine>();
            vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
            string id = (string)listBoxStorage.SelectedValue;

            Vaccine delVaccine = vaccine.Find(x => x.Type == id);
            vaccine.Remove(delVaccine);
            File.WriteAllText(FileOperations.PathStorage, FileOperations.Serializer<Vaccine>(vaccine));
            listBoxStorage.DataSource = vaccine;
            listBoxStorage.DisplayMember = "VaccineInfo";
            listBoxStorage.ValueMember = "Type";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxStorage.DataSource = null;
            List<Vaccine> vaccine = new List<Vaccine>();
            vaccine = FileOperations.Deserializer<Vaccine>(FileOperations.PathStorage);
            listBoxStorage.DataSource = vaccine;
            listBoxStorage.DisplayMember = "VaccineInfo";
            listBoxStorage.ValueMember = "Type";
        }
    }
}
