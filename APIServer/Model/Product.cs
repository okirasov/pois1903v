using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Model
{
    public class Product : Entity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Company Company { get; set; }

        public List<Order> Orders { get; set; }
    }
}
