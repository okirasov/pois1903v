using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.Model
{
    public class User : Entity
    {
        public int Role { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        public Company Company { get; set; }
    }
}
