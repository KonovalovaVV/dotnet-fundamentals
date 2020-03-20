using System;
using System.Data.SqlClient;

namespace CsvEnumerable.DataBase
{
    public class DbConnection
    {
        private static readonly Lazy<DbConnection> Instance =
            new Lazy<DbConnection>(() => new DbConnection());
        public readonly SqlConnection Connection;

        private const string _connectionString = "Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
                                                      + "Integrated Security=true;";

        private DbConnection()
        {
            Connection = new SqlConnection(_connectionString);
            TryConnectAsync();
        }

        private async void TryConnectAsync()
        {
            try
            {
                await Connection.OpenAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DbConnection GetInstance()
        {
            return Instance.Value;
        }
    }
}
