using Appointments.DAO;
using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Service
{
    class AppointmentService
    {
        InterfaceAppointmentDAO appointmentDAO;

        public AppointmentService(InterfaceAppointmentDAO interf)
        {
            this.appointmentDAO = interf;
        }
        public String addAppointment(DateTime dateTime,String clientName,String phoneNr, String services)
        {
            String appointment = "";
            appointment = appointmentDAO.addAppointment(dateTime,clientName,phoneNr,services);
            return appointment;

        }

        public String viewAppointments(String day)
        {
            String appointment;
            appointment = appointmentDAO.viewAppointments(day);
            return appointment;

        }

        public String viewAppointmentsForClient(String clientName)
        {
            String appointment;
            appointment = appointmentDAO.viewAppointmentsForClient(clientName);
            return appointment;

        }

        public String viewAppointmentsBetween2dates(DateTime date1,DateTime date2)
        {
            String appointment;
            appointment = appointmentDAO.viewAppointmentsBetween2dates(date1,date2);
            return appointment;

        }

    }
}
