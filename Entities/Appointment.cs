using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Entities
{
    class Appointment
    {
        private DateTime date;
        private String clientName;
        private String phoneNr;
        private List<String> servicesList = new List<String>();

        public Appointment(DateTime date, string clientName, string phoneNr, List<String> servicesList)
        {
            this.date = date;
            this.clientName = clientName;
            this.phoneNr = phoneNr;
            this.servicesList = servicesList;

        }

        public Appointment()
        {
        }

        public override string ToString()
        {
            String ret = "";

            ret += date.ToString() + " " + clientName + " " + phoneNr + " ";
            foreach (String i in servicesList)
            {
                ret += i+" ";
            }
            return ret;
        }

        public void addService(String service)
        {
            servicesList.Add(service);
        }

        public void setListServices(List<String> services)
        {
            this.servicesList = services;
        }


        public String getServices()
        {
            return string.Join(",", servicesList);
        }

        public List<String> getServicesList()
        {
            return this.servicesList;
        }

        public DateTime getDate()
        {
            return this.date;
        }

        public String getClientName()
        {
            return this.clientName;
        }

        public String getPhoneNr()
        {
            return this.phoneNr;
        }

        public void setDate(DateTime dateTime)
        {
            this.date = dateTime;
        }

        public void setClientName(string v)
        {
            this.clientName = v;
        }

        internal void setPhoneNr(string v)
        {
            this.phoneNr = v;
        }
    }
}
