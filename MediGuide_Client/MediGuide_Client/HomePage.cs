using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediGuide_Client
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin adminLoginForm = new AdminLogin();
            adminLoginForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MedicineInfo medicineInformationForm = new MedicineInfo();
            medicineInformationForm.Show();
            this.Hide();
        }
    }
}
