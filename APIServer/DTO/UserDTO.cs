using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServer.Model;

namespace APIServer.DTO
{
    public class UserDTO : EntityDTO
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }

        public int? CompanyID { get; set; }

        public string CompanyName { get; set; }

        public UserDTO (User u)
        {
            ID = u.ID;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Email = u.Email;
            CompanyID = u.Company?.ID;
            CompanyName = u.Company?.Name;
        }
    }
}
