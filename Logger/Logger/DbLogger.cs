using System;
using System.Data.SqlClient;

namespace Logger
{
    public class DbLogger : ILogger
    {
        public readonly string ConnectionString;

        public DbLogger(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Error(string message)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(message, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }

        public void Error(Exception ex)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("Exception thrown " + ex.Message, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }

        public void Warning(string message)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("Warning:  " + message, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }

        public void Info(string message)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand("Info: " + message, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
}