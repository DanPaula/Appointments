using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.DAO
{
    interface InterfaceUserDAO
    {
        User getUser(String username, String password);
        User createUser(String name, String username, String password, String role);

    }
}
