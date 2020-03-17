using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;
using WebServer.Interfaces;

namespace WebServer.Logic
{
    public class CompanyService : EntityService<Company>, ICompanyService
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Company] (Name, Address)
              VALUES (@Name, @Address)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Company] SET Name = @Name, 
              Address = @Address WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Company entity)
        {
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Address", entity.Address);
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
