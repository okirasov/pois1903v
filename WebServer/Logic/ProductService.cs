using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;
using WebServer.Interfaces;

namespace WebServer.Logic
{
    public class ProductService : EntityService<Product>, IProductService
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Product] (Name, Price, CompanyID)
              VALUES (@Name, @Price, @CompanyID)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Product] SET Name = @Name, Price = @Price,
              CompanyID = @CompanyID WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Product entity)
        {
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@CompanyID", entity.CompanyID);
        }

        protected override Product LoadRow(IDataRecord row)
        {
            Product Product = new Product();

            Product.ID = Convert.ToInt32(row["ID"]);
            Product.Name = Convert.ToString(row["Name"]);
            Product.Price = Convert.ToDecimal(row["Price"]);
            Product.CompanyID = Convert.ToInt32(row["CompanyID"]);

            return Product;
        }
    }
}
