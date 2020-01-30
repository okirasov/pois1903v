using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class CompanyService
    {
        private const string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string insertCommand =
            @"INSERT INTO [Company] (Name, Address)
              VALUES (@Name, @Address)";

        private const string selectCommand =
            @"SELECT * FROM [Company]";

        private const string getCommand =
            @"SELECT * FROM [Company] WHERE ID = @ID";

        private const string updateCommand =
            @"UPDATE [Company] SET Name = @Name, Address = @Address WHERE ID = @ID";

        private const string deleteCommand =
            @"DELETE FROM [Company] WHERE ID = @ID";


        public List<Company> Get()
        {
            var list = new List<Company>();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(selectCommand, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    var company = LoadRow((IDataRecord)reader);
                    list.Add(company);
                }

                // Call Close when done reading.
                reader.Close();
            }

            return list;
        }

        public Company Get(int id)
        {
            var company = new Company();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(getCommand, connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    company = LoadRow((IDataRecord)reader);
                }

                // Call Close when done reading.
                reader.Close();
            }

            return company;
        }
        private Company LoadRow(IDataRecord row)
        {
            Company company = new Company();

            company.ID = Convert.ToInt32(row["ID"]);
            company.Name = Convert.ToString(row["Name"]);
            company.Address = Convert.ToString(row["Address"]);

            return company;
        }
    }


}
