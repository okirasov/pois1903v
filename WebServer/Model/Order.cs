using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Order : Entity
    {
        public string OrderID;

        public DateTime CreateDate;

        public DateTime ShipDate;

        public decimal Price;

        public int ProductID;
    }
}
