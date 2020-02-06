using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class CompanyService : EntityService<Company>
    {
        private const string insertCommand =
            @"INSERT INTO [Company] (Name, Address)
              VALUES (@Name, @Address)";

        private const string updateCommand =
            @"UPDATE [Company] SET Name = @Name, 
              Address = @Address WHERE ID = @ID";


        protected override SqlCommand GetInsertCommand(Company company)
        {
            SqlCommand command = new SqlCommand(insertCommand);
            command.Parameters.AddWithValue("@Name", company.Name);
            command.Parameters.AddWithValue("@Address", company.Address);

            return command;
        }

        public bool Update(int id, Company company)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(updateCommand, connection);
                command.Parameters.AddWithValue("@Name", company.Name);
                command.Parameters.AddWithValue("@Address", company.Address);

                connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        protected override Company LoadRow(IDataRecord row)
        {
            Company company = new Company();

            company.ID = Convert.ToInt32(row["ID"]);
            company.Name = Convert.ToString(row["Name"]);
            company.Address = Convert.ToString(row["Address"]);

            return company;
        }
    }


}
