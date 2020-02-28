using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.Model
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<User> Users { get; set; }
    }
}
