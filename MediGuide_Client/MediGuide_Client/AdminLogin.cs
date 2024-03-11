using MediGuide_Client.AdminService;
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
    public partial class AdminLogin : Form
    {
        private AdminServiceClient adminService = new AdminServiceClient(); // Now AdminService should be accessible
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adminId = int.Parse(textBox1.Text);
            string password = textBox2.Text;

            // Validate the login
            bool isValidLogin = adminService.ValidateLogin(adminId, password);

            if (isValidLogin)
            {
                // Login successful, navigate to AdminHomePage
                AdminHomePage adminHomePage = new AdminHomePage();
                adminHomePage.Show();
                this.Hide(); // Hide the current login form
            }
            else
            {
                MessageBox.Show("Invalid adminId or password. Please try again.");
            }
        }
    }
}
