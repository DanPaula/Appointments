using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Entities
{
    class User
    {
        private String username;
        private String password;
        private String name;
        private String role;

        public User(string v1, string v2, string v3, string v4)
        {
            this.username = v1;
            this.password = v2;
            this.name = v3;
            this.role = v4;
        }

        public String getRole()
        {
            return this.role;
        }

        public String getUsername()
        {
            return this.username;
        }
        public String getPassword()
        {
            return this.password;
        }

    }
}
