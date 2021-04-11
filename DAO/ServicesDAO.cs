using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.DAO
{
    class ServicesDAO : InterfaceServicesDAO
    {
        private static UsersDAO _usersDAO = null;
        private String _connectionString = @"Data Source=LAPTOP-AHC2IA74\SQLEXPRESS;Initial Catalog=lab2;Integrated Security=True";

        SqlConnection _conn = null;

        public ServicesDAO()
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

        public Services addService(String service, double price)
        {
            Services u = null;
            String query = "INSERT INTO dbo.Services (ServiceName,Price) VALUES('" + service + "','" + price + "')";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }

        public Services modifyService(String oldService,String newService, double price)
        {
            Services u = null;
            String query = "UPDATE dbo.Services SET ServiceName = @NewName, Price = @Price WHERE ServiceName = @OldName";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.Parameters.AddWithValue("OldName",oldService);
                cmd.Parameters.AddWithValue("Price", price);
                cmd.Parameters.AddWithValue("NewName", newService);
                cmd.ExecuteNonQuery();
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }

        public List<Services> getServices()
        {
            List<Services> u = new List<Services>() ;
            String query = "select *from dbo.Services";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Services s = new Services();
                    s.setServiceName(reader.GetString(reader.GetOrdinal("ServiceName")));
                    s.setPrice(reader.GetDouble(reader.GetOrdinal("Price")));
                    u.Add(s);
                }
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }
    }
}
