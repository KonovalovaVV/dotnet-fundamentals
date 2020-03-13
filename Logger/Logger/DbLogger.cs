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
            ExecuteCommand(Titles.Error + message);
        }

        public void Error(Exception ex)
        {
            ExecuteCommand(Titles.Exception + ex.Message);
        }

        public void Warning(string message)
        {
            ExecuteCommand(Titles.Warning + message);
        }

        public void Info(string message)
        {
            ExecuteCommand(Titles.Info + message);
        }

        private void ExecuteCommand(string message)
        {
            using SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(message, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
}