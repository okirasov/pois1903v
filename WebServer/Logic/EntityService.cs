using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Model;

namespace WebServer.Logic
{
    public abstract class EntityService <T> where T:Entity
    {
        protected const string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string selectCommand =
            @"SELECT * FROM [{0}]";

        private const string getCommand =
            @"SELECT * FROM [{0}] WHERE ID = @ID";

        private const string deleteCommand =
            @"DELETE FROM [{0}] WHERE ID = @ID";

        protected string FormatQuery(string query)
        {
            var type = typeof(T).Name;
            return string.Format(query, type);
        }

        protected abstract T LoadRow(IDataRecord row);

        protected abstract SqlCommand GetInsertCommand(T entity);

        public List<T> Get()
        {
            var list = new List<T>();

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    FormatQuery(selectCommand), connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    var entity = LoadRow((IDataRecord)reader);
                    list.Add(entity);
                }

                // Call Close when done reading.
                reader.Close();
            }

            return list;
        }

        public T Get(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    FormatQuery(getCommand), connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    return LoadRow((IDataRecord)reader);
                }

                // Call Close when done reading.
                reader.Close();
            }

            return null;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    FormatQuery(deleteCommand), connection);
                command.Parameters.AddWithValue("@ID", id);

                connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool Create(T entity)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = GetInsertCommand(entity);
                command.Connection = connection;

                connection.Open();
                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }
    }
}
