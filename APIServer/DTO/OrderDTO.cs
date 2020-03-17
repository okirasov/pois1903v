using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServer.Model;

namespace APIServer.DTO
{
    public class OrderDTO : EntityDTO
    {
        public string OrderID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ShipDate { get; set; }

        public decimal Price { get; set; }

        public int? ProductID { get; set; }

        public string ProductName { get; set; }

        public OrderDTO(Order o)
        {
            if (o != null)
            {
                ID = o.ID;
                OrderID = o.OrderID;
                CreateDate = o.CreateDate;
                ShipDate = o.ShipDate;
                Price = o.Price;
                ProductID = o.Product?.ID;
                ProductName = o.Product?.Name;
            }
        }
    }
}
