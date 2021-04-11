using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Appointments.Entities;

namespace Appointments.DAO
{
    class UsersDAO : InterfaceUserDAO
    {
        private static UsersDAO _usersDAO = null;
        private String _connectionString = @"Data Source=LAPTOP-AHC2IA74\SQLEXPRESS;Initial Catalog=lab2;Integrated Security=True";


        SqlConnection _conn = null;

        public UsersDAO()
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

        public static UsersDAO getInstance()
        {
            if (_usersDAO == null)
            {
                _usersDAO = new UsersDAO();
            }
            return _usersDAO;
        }



        public User getUser(String username, String password)
        {
            User u = null;
            String sql = "SELECT * FROM dbo.users WHERE username='" + username + "' AND password='" + password + "'";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                _conn.Close();

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return u;
        }

        public User createUser(String name, String username,String password,String role)
        {
            User u = null;
            String query = "INSERT INTO dbo.users (username,password,name,role) VALUES('"+username+"','"+password+"','"+name+"','"+role+"')";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(query, _conn);
                cmd.ExecuteNonQuery();
                //u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
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
