using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments.GUI
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        //create Appointment
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAppointmentForm createAppointmentForm = new CreateAppointmentForm();
            createAppointmentForm.ShowDialog();
        }

        //view Appointment
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAppointmentsForm viewAppointmentForm = new ViewAppointmentsForm();
            viewAppointmentForm.ShowDialog();
        }

        //back
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }
    }
}
