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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Appointments.GUI
{
    public partial class CreateUserForm : Form
    {
        UserService userService;
        public CreateUserForm()
        {
            InitializeComponent();
            Type obj = Type.GetType(ConfigurationManager.AppSettings["UsersDAO"]);
            ConstructorInfo constructor = obj.GetConstructor(new Type[] { });
            InterfaceUserDAO defaultRepository = (InterfaceUserDAO)constructor.Invoke(null);

            userService = new UserService(defaultRepository);
        }

        //create user
        private void button1_Click(object sender, EventArgs e)
        {
            string usernamePattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            string namePattern = "^[A-Z][a-zA-Z]*$";
            String user = "user";
            String admin = "admin";
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                    return;
                }
                else if (!Regex.IsMatch(textBox2.Text, usernamePattern))
                {
                    MessageBox.Show("Please enter a valid email", "Error");
                    return;
                }
                else if (!Regex.IsMatch(textBox1.Text, namePattern))
                {
                    MessageBox.Show("Please enter a valid name", "Error");
                    return;
                }
                else if (!String.Equals(textBox4.Text,user) && !String.Equals(textBox4.Text, admin))
                {
                    MessageBox.Show("Please enter a valid role", "Error");
                    return;
                }
                else
                {
                    User tryUSer = userService.createUser(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                }
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
