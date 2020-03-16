using System;
using System.Data.SqlClient;

namespace LoggingProxy.Logger
{
    public class DbLogger : BaseLogger
    {
        public readonly string ConnectionString;

        public DbLogger(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void Write(LogLevel level, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            using SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand($"{DateTime.Now}: {level.ToString()}" + message, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
