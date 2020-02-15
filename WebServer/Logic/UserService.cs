using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class UserService : EntityService<User>
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [User] (Role, Email, FirstName, LastName, Password)
              VALUES (@Role, @Email, @FirstName, @LastName, @Password)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [User] SET Role = @Role, Email = @Email, FirstName = @FirstName, 
              LastName = @LastName, Password = @Password WHERE ID = @ID";
            }
        }

        public bool Login(string email, string password)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
    SqlCommand command = new SqlCommand(
        @"SELECT COUNT(*) FROM [User]
        WHERE Email = @Email AND Password = @Password"
        , connection);
    command.Parameters.AddWithValue("@Email", email);
    command.Parameters.AddWithValue("@Password", password ?? "");

    connection.Open();

    var result = Convert.ToInt32(command.ExecuteScalar());
    return result > 0;
            }
        }

        protected override void AddParameters(SqlCommand command, User entity)
        {
            command.Parameters.AddWithValue("@Role", entity.Role);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Password", entity.Password);
        }

        protected override User LoadRow(IDataRecord row)
        {
            User user = new User();

            user.ID = Convert.ToInt32(row["ID"]);

            if (!(row["Role"] is DBNull))
                user.Role = Convert.ToInt32(row["Role"]);

            user.Email = Convert.ToString(row["Email"]);
            user.Password = Convert.ToString(row["Password"]);
            user.FirstName = Convert.ToString(row["FirstName"]);
            user.LastName = Convert.ToString(row["LastName"]);

            return user;
        }
    }
}
