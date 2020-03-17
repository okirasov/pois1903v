using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;
using WebServer.Interfaces;

namespace WebServer.Logic
{
    public class OrderService : EntityService<Order>, IOrderService
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Order] (OrderID, Price, CreateDate, ShipDate, ProductID)
              VALUES (@OrderID, @Price, @CreateDate, @ShipDate, @ProductID)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Order] SET Name = @Name, Price = @Price,
              CreateDate = @CreateDate, ShipDate = @ShipDate,
              ProductID = @ProductID WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Order entity)
        {
            command.Parameters.AddWithValue("@OrderID", entity.OrderID);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@CreateDate", entity.CreateDate);
            command.Parameters.AddWithValue("@ShipDate", entity.ShipDate);
            command.Parameters.AddWithValue("@ProductID", entity.ProductID);
        }

        protected override Order LoadRow(IDataRecord row)
        {
            Order Order = new Order();

            Order.ID = Convert.ToInt32(row["ID"]);
            Order.OrderID = Convert.ToString(row["OrderID"]);
            Order.Price = Convert.ToDecimal(row["Price"]);
            Order.CreateDate = Convert.ToDateTime(row["CreateDate"]);
            Order.ShipDate = Convert.ToDateTime(row["ShipDate"]);
            Order.ProductID = Convert.ToInt32(row["ProductID"]);

            return Order;
        }
    }


}
