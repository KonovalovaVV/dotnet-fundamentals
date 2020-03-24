using CsvDataBase.DataBase;
using CsvEnumberable.Test;

namespace CsvDataBase.Repository
{
    public class Repository<T>: IRepository<T> where T : IPerson
    {
        private readonly DbCommandExecutor _commandExecutor;
        private readonly DbConnection _dbConnection;
        private static int _nextId = 1;

        public Repository()
        {
            _dbConnection = DbConnection.GetInstance();
            _commandExecutor = new DbCommandExecutor(_dbConnection);
        }

        ~Repository()
        {
            _dbConnection.Connection.Close();
        }

        public void Add(T entity)
        {
            _commandExecutor.ExecuteCommand
                ($"INSERT INTO Persons (Id, FirstName, SecondName, Age) VALUES ({_nextId++}, '{entity.FirstName}', '{entity.SecondName}', {entity.Age});");
        }
    }
}
