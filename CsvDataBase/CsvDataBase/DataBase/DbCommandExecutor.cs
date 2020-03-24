using System.Data.SqlClient;

namespace CsvDataBase.DataBase
{
    public class DbCommandExecutor
    {
        private readonly DbConnection _dbConnection;

        public DbCommandExecutor(DbConnection db)
        {
            _dbConnection = db;
        }

        public void ExecuteCommand(string queryString)
        {
            try
            {
                SqlCommand command = new SqlCommand(queryString, _dbConnection.Connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
