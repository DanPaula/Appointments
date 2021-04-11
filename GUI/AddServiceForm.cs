using Appointments.DAO;
using Appointments.Entities;
using Appointments.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments.GUI
{
    public partial class AddServiceForm : Form
    {
        ServicesService service;
        public AddServiceForm()
        {
            InitializeComponent();
            Type obj = Type.GetType(ConfigurationManager.AppSettings["ServicesRep"]);
            ConstructorInfo constructor = obj.GetConstructor(new Type[] { });
            InterfaceServicesDAO defaultRepository = (InterfaceServicesDAO)constructor.Invoke(null);

            service = new ServicesService(defaultRepository);
        }

        //add service
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Services tryService = service.addService(textBox1.Text, double.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conexiune invalida");
            }
        }

        //back
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }
    }
}
