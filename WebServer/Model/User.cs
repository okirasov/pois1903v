using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebServer.Model
{
    public class User : Entity
    {
        public int Role { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        //        public Company Company { get; set; }
    }
}
