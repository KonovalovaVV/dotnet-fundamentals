using CsvDataBase.DataBase;

namespace CsvDataBase.Repository
{
    public class Repository<T>: IRepository<T>
    {
        private readonly DbCommandExecutor _commandExecutor;

        public Repository()
        {
            DbConnection _dbConnection = DbConnection.GetInstance();
            _commandExecutor = new DbCommandExecutor(_dbConnection);
        }

        public void Add(T entity)
        {
            _commandExecutor.ExecuteCommandAsync($"INSERT INTO Persons (Person) VALUES {entity};");
        }

        public void Delete(int id)
        {
            _commandExecutor.ExecuteCommandAsync($"DELETE FROM Persons WHERE id = {id};");
        }
    }
}
