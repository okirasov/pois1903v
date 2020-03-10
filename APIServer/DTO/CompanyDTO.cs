using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServer.Model;

namespace APIServer.DTO
{
    public class CompanyDTO : EntityDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int UsersCount { get; set; }

        public CompanyDTO(Company c)
        {
            ID = c.ID;
            Name = c.Name;
            Address = c.Address;
            UsersCount = c.Users?.Count() ?? 0;
        }
    }
}
