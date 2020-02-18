using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class OrderService : EntityService<Order>
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Order] (Name, Address)
              VALUES (@Name, @Address)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Order] SET Name = @Name, 
              Address = @Address WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Order entity)
        {
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Address", entity.Address);
        }

        protected override Order LoadRow(IDataRecord row)
        {
            Order Order = new Order();

            Order.ID = Convert.ToInt32(row["ID"]);
            Order.Name = Convert.ToString(row["Name"]);
            Order.Address = Convert.ToString(row["Address"]);

            return Order;
        }
    }


}
