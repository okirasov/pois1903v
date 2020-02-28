using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Company Company { get; set; }

        public List<Order> Orders { get; set; }
    }
}
