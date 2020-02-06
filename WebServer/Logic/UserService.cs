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
        private const string insertCommand =
            @"INSERT INTO [User] (Role, Email, FirstName, LastName, Password)
              VALUES (@Role, @Email, @FirstName, @LastName, @Password)";

        private const string updateCommand =
            @"UPDATE [User] SET Role = @Role, Email = @Email, FirstName = @FirstName, 
              LastName = @LastName, Password = @Password WHERE ID = @ID";

        protected override SqlCommand GetInsertCommand(User user)
        {
            SqlCommand command = new SqlCommand(insertCommand);
            command.Parameters.AddWithValue("@Role", user.Role);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Password", user.Password);

            return command;
        }

        public bool Update(int id, User user)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(updateCommand, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Password", user.Password);

                connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
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
