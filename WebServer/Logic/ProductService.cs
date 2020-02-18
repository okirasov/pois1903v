using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class ProductService : EntityService<Product>
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Product] (Name, Address)
              VALUES (@Name, @Address)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Product] SET Name = @Name, 
              Address = @Address WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Product entity)
        {
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Address", entity.Address);
        }

        protected override Product LoadRow(IDataRecord row)
        {
            Product Product = new Product();

            Product.ID = Convert.ToInt32(row["ID"]);
            Product.Name = Convert.ToString(row["Name"]);
            Product.Address = Convert.ToString(row["Address"]);

            return Product;
        }
    }
}
}
