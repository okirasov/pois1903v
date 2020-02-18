using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Order : Entity
    {
        public string OrderID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ShipDate { get; set; }

        public decimal Price { get; set; }

        public int ProductID { get; set; }
    }
}
