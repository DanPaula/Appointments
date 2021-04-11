using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.DAO
{
    interface InterfaceAppointmentDAO
    {
        String addAppointment(DateTime dateTime, String clientName, String phoneNr, String services);
        String viewAppointments(String day);
        String viewAppointmentsForClient(String clientName);
        String viewAppointmentsBetween2dates(DateTime date1, DateTime date2);
    }
}
