using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public List<Product> Products { get; set; }
    }

    public class CompanyDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ProductList { get; set; }

        public int ProductCount { get; set; }

        public int UserCount { get; set; }
    }
}
