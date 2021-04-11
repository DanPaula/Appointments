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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        
        //create services
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddServiceForm addServiceForm = new AddServiceForm();
            addServiceForm.ShowDialog();

        }

        //create user
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateUserForm createUserForm = new CreateUserForm();
            createUserForm.ShowDialog();
            

        }

        //back
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        //modify service
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModifyServiceForm modifyServiceForm = new ModifyServiceForm();
            modifyServiceForm.ShowDialog();
        }

        //view app for a client
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewApClientForm modifyServiceForm = new ViewApClientForm();
            modifyServiceForm.ShowDialog();
        }

        //view app between dates
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewApBetween2Dates modifyServiceForm = new ViewApBetween2Dates();
            modifyServiceForm.ShowDialog();
        }
    }
}
