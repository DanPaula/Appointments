using Appointments.DAO;
using Appointments.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments.GUI
{
    public partial class ViewAppointmentsForm : Form
    {
        AppointmentService appointment;
        public ViewAppointmentsForm()
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

                textBox1.Text = appointment.viewAppointments(textBox2.Text);
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
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
        }
    }
}
