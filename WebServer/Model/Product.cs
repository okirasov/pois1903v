using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompanyID { get; set; }

        public Company Company { get; set; }
    }


    public class ProductDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompanyID { get; set; }

        public string CompanyName { get; set; }
    }

}
