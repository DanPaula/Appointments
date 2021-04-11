using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.DAO
{
    class AppointmentDAO : InterfaceAppointmentDAO
    {
        private String _connectionString = @"Data Source=LAPTOP-AHC2IA74\SQLEXPRESS;Initial Catalog=lab2;Integrated Security=True";

        SqlConnection _conn = null;

        public AppointmentDAO()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                //de facut ceva error handling, afisat mesaj, etc..
                _conn = null;
            }
        }

        public String addAppointment(DateTime dateTime, String clientName, String phoneNr, String services)
        {
            String stringOut = "";
            List<String> list = new List<String>();
            list = services.Split(',').ToList<String>();

            List<Appointment> listAp = new List<Appointment>();
            List<Services> listS = new List<Services>();

            String dayAp, monthAp, yearAp, hourAp, minuteAp;
            dayAp = dateTime.Day.ToString();
            monthAp = dateTime.Month.ToString();
            yearAp = dateTime.Year.ToString();
            hourAp = dateTime.Hour.ToString();
            minuteAp = dateTime.Minute.ToString();

            String querySel = "select *from dbo.Appointments";
            String query = "INSERT INTO dbo.Appointments (Date,ClientName,PhoneNr,Services) VALUES(@date, @clientName,@phoneNr,@services)";
            String queryServices = "select* from dbo.Services";
            
            try
            {
                _conn.Open();

                SqlCommand cmdSelect = new SqlCommand(querySel, _conn);
                SqlDataReader reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    Appointment s = new Appointment();

                    s.setDate(reader.GetDateTime(reader.GetOrdinal("Date")));
                    s.setClientName(reader.GetString(reader.GetOrdinal("ClientName")));
                    s.setPhoneNr(reader.GetString(reader.GetOrdinal("PhoneNr")));
                    List<String> listServices = new List<String>();
                    String serv = reader.GetString(reader.GetOrdinal("Services"));
                    listServices = serv.Split(',').ToList<String>();
                    s.setListServices(listServices);
                    listAp.Add(s);
                }
                _conn.Close();

                _conn.Open();

                SqlCommand cmdServ = new SqlCommand(queryServices, _conn);
                SqlDataReader readerServ = cmdServ.ExecuteReader();

                while (readerServ.Read())
                {
                    Services s = new Services();

                    s.setServiceName(readerServ.GetString(readerServ.GetOrdinal("ServiceName")));
                    s.setPrice(readerServ.GetDouble(readerServ.GetOrdinal("Price")));                                
                    listS.Add(s);
                }
                _conn.Close();
                _conn.Open();

                //get price for appointment
                double price = 0;
                foreach(Services i in listS)
                {
                   foreach(String j in list)
                    {
                        if(i.getServiceName() == j)
                        {
                            price += i.getPrice();
                        }
                    }
                }

                

                int ok = 0;
                int rest = 0;
                int yearDif = 0;
                int monthDif = 0;
                int dayDif = 0;
                int hourDif = 0;
                int minDif = 0;
                if (listAp.Count > 0)
                {

                    foreach (Appointment i in listAp)
                    {
                        
                        String day, month, year, hour, minute;
                        day = i.getDate().Day.ToString();
                        month = i.getDate().Month.ToString();
                        year = i.getDate().Year.ToString();
                        hour = i.getDate().Hour.ToString();
                        minute = i.getDate().Minute.ToString();
                        //year dif nu mai verific restul
                        if (yearAp != year)
                        {
                            yearDif = 1;
                            rest = 1;
                        }
                        else if (monthAp != month)
                        {
                            monthDif = 1;
                            rest = 1;
                        }
                        else if (dayAp != day)
                        {
                            dayDif = 1;
                            rest = 1;
                        }
                        else if (hourAp != hour)
                        {
                            hourDif = 1;
                            rest = 1;
                        }
                     
                        else if (minuteAp != minute)
                        {
                            minDif = 1;
                            rest = 1;
                        }
                        
                        //cand data de app este la fel cu una sau mai multe deja setate atunci verific ca serviciile sa fie diferite
                        else if (yearAp == year && monthAp == month && dayAp == day && hourAp == hour && minuteAp == minute)
                        {

                            foreach (String addS in list) //parcurg lista de servicii din cele selectate la appointment
                            {
                                foreach (String j in i.getServicesList()) //parcurg lista de servicii din appointment
                                {
                                    if (addS != j)
                                    {
                                        ok = 1;   //daca toate serviciile sunt diferite atunci voi insera in tabela
                                    }
                                    else
                                    {
                                        ok = 0;
                                        break;
                                    }
                                }
                                if (ok == 0)
                                    break;
                            }
                            if (ok == 0)
                                break;

                        }
                        
                    }
                    if (ok == 0 && rest==0)
                    {
                        return "cannot add appointment";
                    }
                    else if (yearDif == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query, _conn);
                        cmd.Parameters.AddWithValue("@date", dateTime);
                        cmd.Parameters.AddWithValue("@clientName", clientName);
                        cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
                        cmd.Parameters.AddWithValue("@services", services);
                        cmd.ExecuteNonQuery();
                    }
                    else if (monthDif == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query, _conn);
                        cmd.Parameters.AddWithValue("@date", dateTime);
                        cmd.Parameters.AddWithValue("@clientName", clientName);
                        cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
                        cmd.Parameters.AddWithValue("@services", services);
                        cmd.ExecuteNonQuery();
                    }
                    else if (dayDif == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query, _conn);
                        cmd.Parameters.AddWithValue("@date", dateTime);
                        cmd.Parameters.AddWithValue("@clientName", clientName);
                        cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
                        cmd.Parameters.AddWithValue("@services", services);
                        cmd.ExecuteNonQuery();
                    }
                    else if (hourDif == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query, _conn);
                        cmd.Parameters.AddWithValue("@date", dateTime);
                        cmd.Parameters.AddWithValue("@clientName", clientName);
                        cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
                        cmd.Parameters.AddWithValue("@services", services);
                        cmd.ExecuteNonQuery();
                    }
                    else if (minDif == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query, _conn);
                        cmd.Parameters.AddWithValue("@date", dateTime);
                        cmd.Parameters.AddWithValue("@clientName", clientName);
                        cmd.Parameters.AddWithValue("@phoneNr", phoneNr);
                        cmd.Parameters.AddWithValue("@services", services);
                        cmd.ExecuteNonQuery();
                    }
                    else if (ok == 1)
                    {
                        SqlCommand cmd = new SqlCommand(query, _conn);
                        cmd.Parameters.AddWithValue("date", dateTime);
                        cmd.Parameters.AddWithValue("clientName", clientName);
                        cmd.Parameters.AddWithValue("phoneNr", phoneNr);
                        cmd.Parameters.AddWithValue("services", services);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, _conn);
                    cmd.Parameters.AddWithValue("date", dateTime);
                    cmd.Parameters.AddWithValue("clientName", clientName);
                    cmd.Parameters.AddWithValue("phoneNr", phoneNr);
                    cmd.Parameters.AddWithValue("services", services);
                    cmd.ExecuteNonQuery();

                }

                stringOut += "Price= "+price;
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return "could not insert";
            }
            return stringOut;
        }

        public String viewAppointments(String day)
        {
            List<Appointment> u = new List<Appointment>();
            String querySel = "select *from dbo.Appointments";
            String appointments="";

            try
            {
                _conn.Open();

                SqlCommand cmdSelect = new SqlCommand(querySel, _conn);
                SqlDataReader reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    Appointment s = new Appointment();

                    s.setDate(reader.GetDateTime(reader.GetOrdinal("Date")));
                    s.setClientName(reader.GetString(reader.GetOrdinal("ClientName")));
                    s.setPhoneNr(reader.GetString(reader.GetOrdinal("PhoneNr")));
                    List<String> listServices = new List<String>();
                    String serv = reader.GetString(reader.GetOrdinal("Services"));
                    listServices = serv.Split(',').ToList<String>();
                    s.setListServices(listServices);
                    u.Add(s);
                }
                _conn.Close();


                foreach(Appointment i in u)
                {
                    String dayFound = i.getDate().Day.ToString();
                    if (dayFound == day)
                    {
                        appointments += i.ToString() + "\n";
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return appointments;
        }

        public String viewAppointmentsForClient(String clientName)
        {
            List<Appointment> u = new List<Appointment>();
            String querySel = "select *from dbo.Appointments";
            String appointments = "";

            try
            {
                _conn.Open();

                SqlCommand cmdSelect = new SqlCommand(querySel, _conn);
                SqlDataReader reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    Appointment s = new Appointment();

                    s.setDate(reader.GetDateTime(reader.GetOrdinal("Date")));
                    s.setClientName(reader.GetString(reader.GetOrdinal("ClientName")));
                    s.setPhoneNr(reader.GetString(reader.GetOrdinal("PhoneNr")));
                    List<String> listServices = new List<String>();
                    String serv = reader.GetString(reader.GetOrdinal("Services"));
                    listServices = serv.Split(',').ToList<String>();
                    s.setListServices(listServices);
                    u.Add(s);
                }
                _conn.Close();


                foreach (Appointment i in u)
                {
                  
                    if (i.getClientName() == clientName)
                    {
                        appointments += i.ToString() + "\n";
                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return appointments;
        }

        public String viewAppointmentsBetween2dates(DateTime date1, DateTime date2)
        {
            List<Appointment> u = new List<Appointment>();
            String querySel = "select *from dbo.Appointments";
            String appointments = "";

            long ticks1 = date1.Ticks;
            long ticks2 = date2.Ticks;

            try
            {
                _conn.Open();

                SqlCommand cmdSelect = new SqlCommand(querySel, _conn);
                SqlDataReader reader = cmdSelect.ExecuteReader();

                while (reader.Read())
                {
                    Appointment s = new Appointment();

                    s.setDate(reader.GetDateTime(reader.GetOrdinal("Date")));
                    s.setClientName(reader.GetString(reader.GetOrdinal("ClientName")));
                    s.setPhoneNr(reader.GetString(reader.GetOrdinal("PhoneNr")));
                    List<String> listServices = new List<String>();
                    String serv = reader.GetString(reader.GetOrdinal("Services"));
                    listServices = serv.Split(',').ToList<String>();
                    s.setListServices(listServices);
                    u.Add(s);
                }
                _conn.Close();


                foreach (Appointment i in u)
                {
                    if(i.getDate().Ticks>=ticks1 && i.getDate().Ticks <= ticks2)
                    {
                        appointments += i.ToString() + "\n";
                    }                  
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return appointments;
        }
    }
}
