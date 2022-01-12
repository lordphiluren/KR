using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using VaccineBlank;

namespace WinForms
{
    public partial class PatientEditForm : Form
    {
        public PatientEditForm()
        {
            InitializeComponent();
            if (File.Exists(FileOperations.PathPatient))
            {
                List<Patient> patient = new List<Patient>();
                patient = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
                listBoxPatients.DataSource = patient;
                listBoxPatients.DisplayMember = "FullInfo";
                listBoxPatients.ValueMember = "PassportInfo";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<Patient> patient = new List<Patient>();
            patient = FileOperations.Deserializer<Patient>(FileOperations.PathPatient);
            string id = (string)listBoxPatients.SelectedValue;
            Patient delPatient = patient.Find(x => x.PassportInfo == id);
            patient.Remove(delPatient);
            File.WriteAllText(FileOperations.PathPatient, FileOperations.Serializer<Patient>(patient));
            listBoxPatients.DataSource = patient;
            listBoxPatients.DisplayMember = "FullInfo";
            listBoxPatients.ValueMember = "PassportInfo";
        }
    }
}
