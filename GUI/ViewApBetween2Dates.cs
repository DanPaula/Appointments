using Appointments.DAO;
using Appointments.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments.GUI
{
    public partial class ViewApBetween2Dates : Form
    {
        AppointmentService appointment;
        public ViewApBetween2Dates()
        {
            InitializeComponent();
            Type obj2 = Type.GetType(ConfigurationManager.AppSettings["AppointmentRep"]);
            ConstructorInfo constructor = obj2.GetConstructor(new Type[] { });
            InterfaceAppointmentDAO defaultRepository2 = (InterfaceAppointmentDAO)constructor.Invoke(null);

            appointment = new AppointmentService(defaultRepository2);

        }

        //view
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date1 = DateTime.Parse(textBox1.Text);
                DateTime date2 = DateTime.Parse(textBox2.Text);
                textBox3.Text = appointment.viewAppointmentsBetween2dates(date1,date2);
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
            AdminForm employeeForm = new AdminForm();
            employeeForm.ShowDialog();
        }
    }
}
