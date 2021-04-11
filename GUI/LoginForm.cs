using Appointments.DAO;
using Appointments.Entities;
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
    public partial class LoginForm : Form
    {
        UserService userService;
        public LoginForm()
        {
            InitializeComponent();
            Type obj = Type.GetType(ConfigurationManager.AppSettings["UsersDAO"]);
            ConstructorInfo constructor = obj.GetConstructor(new Type[] { });
            InterfaceUserDAO defaultRepository = (InterfaceUserDAO)constructor.Invoke(null);

            userService = new UserService(defaultRepository);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User tryUSer = userService.GetUser(textBox1.Text, textBox2.Text);
                if (tryUSer == null)
                {

                    MessageBox.Show("User invalid");
                }
                if (tryUSer.getRole().Equals("admin"))
                {
                    this.Hide();
                    AdminForm admin = new AdminForm();
                    admin.Show();
                }
                else
                {
                    this.Hide();
                    EmployeeForm other = new EmployeeForm();
                    other.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Conexiune invalida");
            }

        }
    }
}
