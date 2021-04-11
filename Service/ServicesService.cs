using Appointments.DAO;
using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Service
{
    class ServicesService
    {
        InterfaceServicesDAO serviceDAO;

        public ServicesService(InterfaceServicesDAO interf)
        {
            this.serviceDAO = interf;

        }

        public Services addService(String service, double price)
        {
            Services services = null;
            services = serviceDAO.addService(service, price);
            return services;

        }

        public Services modifyService(String oldName, String newName, double price)
        {
            Services services = null;
            services = serviceDAO.modifyService(oldName, newName, price);
            return services;

        }

        public List<Services> getServices()
        {
            List<Services> services = null;
            services = serviceDAO.getServices();
            return services;

        }

    }
}
