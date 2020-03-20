using System.Data.SqlClient;

namespace CsvEnumerable.DataBase
{
    public class DbCommandExecutor
    {
        private readonly DbConnection _dbConnection;

        public DbCommandExecutor(DbConnection db)
        {
            _dbConnection = db;
        }

        public async void ExecuteCommandAsync(string queryString)
        {
            try
            {
                SqlCommand command = new SqlCommand(queryString, _dbConnection.Connection);
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
