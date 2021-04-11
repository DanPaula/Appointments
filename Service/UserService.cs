using Appointments.DAO;
using Appointments.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Appointments.Service
{
    class UserService
    {
        InterfaceUserDAO usersDAO;

        public UserService(InterfaceUserDAO interf)
        {
            this.usersDAO = interf;

        }

        public User GetUser(String username, String password)
        {
            User u = null;
            u = usersDAO.getUser(username, getMd5Hash(password));
            return u;

        }

        public User createUser(String name, String username,String password,String role)
        {
            User u = null;
            u = usersDAO.createUser(name,username, getMd5Hash(password),role);
            return u;

        }

        static string getMd5Hash(string input)
        {

            // Create a new instance of the MD5CryptoServiceProvider object. 

            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash. 

            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 

            // and create a string. 

            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  

            // and format each one as a hexadecimal string. 

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();

        }
    }
}
