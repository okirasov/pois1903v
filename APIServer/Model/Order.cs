using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIServer.Model
{
    public class Order : Entity
    {
        public string OrderID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ShipDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public Product Product { get; set; }
    }
}
