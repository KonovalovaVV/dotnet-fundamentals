using Logger.AppSettings;
using System;
using System.Data.SqlClient;

namespace Logger
{
    public class DbLogger : BaseLogger
    {
        private readonly SqlConnection _connection;

        public DbLogger()
        {
            _connection = new SqlConnection(AppSettingsProvider.GetInstance().Settings.ConnectionString);
            TryConnect();
        }

        private void TryConnect()
        {
            try
            {
                 _connection.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected override void Write(LogLevel level, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            try
            {
                SqlCommand command = new SqlCommand
                ($"INSERT INTO Log (Message, Type, DateTime) VALUES ('{message}', {(int)level}, '{DateTime.Now:yyyy-MM-dd hh:mm:ss}');",
                _connection);
                command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        ~DbLogger()
        {
            _connection.Close();
        }
    }
}