using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.DTO
{
    public class UserDTO : EntityDTO
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        public int CompanyID { get; set; }

        public string CompanyName { get; set; }
    }
}
