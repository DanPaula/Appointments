using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Entities
{
    class Services
    {
        private String serviceName;
        private double price;

        public Services(string serviceName, double price)
        {
            this.serviceName = serviceName;
            this.price = price;
        }

        public Services()
        {
        }

        public String getServiceName()
        {
            return this.serviceName;
        }

        public double getPrice()
        {
            return this.price;
        }

        public void setServiceName(String serviceName)
        {
            this.serviceName = serviceName;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

    }
}
