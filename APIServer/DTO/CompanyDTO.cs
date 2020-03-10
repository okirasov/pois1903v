using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.DTO
{
    public class CompanyDTO : EntityDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int UsersCount { get; set; }
    }
}
