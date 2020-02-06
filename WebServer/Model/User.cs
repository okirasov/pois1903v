using System;
using System.Collections.Generic;

namespace WebServer.Model
{
    public class User : Entity
    {
        public int Role;

        public string Email;

        public string FirstName;

        public string LastName;

        public string Password;

        public string Country;

//        public Company Company;
    }
}
