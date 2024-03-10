using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Data.Common;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Contexts;
using MediGuide;

namespace MediGuideHostConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ServiceHost sh = null;
        ServiceHost bh = null;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Uri httpa = new Uri("http://localhost:8733/Design_Time_Addresses/Aservice");
                sh = new ServiceHost(typeof(AdminService), httpa);
                WSHttpBinding httpb = new WSHttpBinding();
                ServiceMetadataBehavior mbehave = new ServiceMetadataBehavior();
                sh.Description.Behaviors.Add(mbehave);
                sh.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                sh.AddServiceEndpoint(typeof(IAdminService), httpb, httpa);
                sh.Open();

                Uri httpd = new Uri("http://localhost:8733/Design_Time_Addresses/Mservice");
                bh = new ServiceHost(typeof(MedicineService), httpd);
                WSHttpBinding httpc = new WSHttpBinding();
                ServiceMetadataBehavior nbehave = new ServiceMetadataBehavior();
                bh.Description.Behaviors.Add(nbehave);
                bh.AddServiceEndpoint(typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                bh.AddServiceEndpoint(typeof(IMedicineService), httpc, httpd);
                bh.Open();


                label1.Text = "Server Running";
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
