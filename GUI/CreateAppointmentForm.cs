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
    public partial class CreateAppointmentForm : Form
    {
        ServicesService service;
        AppointmentService appointment;
        public CreateAppointmentForm()
        {
            InitializeComponent();
             
            Type obj = Type.GetType(ConfigurationManager.AppSettings["ServicesRep"]);
            ConstructorInfo constructor = obj.GetConstructor(new Type[] { });
            InterfaceServicesDAO defaultRepository = (InterfaceServicesDAO)constructor.Invoke(null);

            service = new ServicesService(defaultRepository);

            Type obj2 = Type.GetType(ConfigurationManager.AppSettings["AppointmentRep"]);
            ConstructorInfo constructor2 = obj2.GetConstructor(new Type[] { });
            InterfaceAppointmentDAO defaultRepository2 = (InterfaceAppointmentDAO)constructor2.Invoke(null);

            appointment = new AppointmentService(defaultRepository2);
            fillListBox();
        }

        void fillListBox()
        {
            
            List<Services> list = service.getServices();
            foreach(Services service in list)
            {
                listBox1.Items.Add(service.getServiceName());
            }
           
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            String phoneNr = "^[0-9]+$";
            try
            {
                if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Please fill in all fields", "Error");
                    return;
                }
                else if(!Regex.IsMatch(textBox4.Text, phoneNr))
                {
                        MessageBox.Show("Please enter a valid phone nr", "Error");
                        return;
                }
                else
                {
                    DateTime dt = DateTime.Parse(textBox1.Text);
                    String text = String.Join(",", listBox1.SelectedItems.OfType<String>());

                    String tryService = appointment.addAppointment(dt, textBox3.Text, textBox4.Text, text);
                    MessageBox.Show(tryService);
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
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.ShowDialog();
        }
    }
}
