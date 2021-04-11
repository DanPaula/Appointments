using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.DAO
{
    interface InterfaceServicesDAO
    {
        Services addService(String service, double price);
        Services modifyService(String oldService, String newService, double price);
        List<Services> getServices();
    }
}
