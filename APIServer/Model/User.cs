using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APIServer.Model
{
    public class User : Entity
    {
        public int Role { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(30)]
        public string Country { get; set; }

        public Company Company { get; set; }
    }
}
