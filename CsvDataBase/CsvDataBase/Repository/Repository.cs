using CsvDataBase.DataBase;
using CsvEnumerable.Test;

namespace CsvDataBase.Repository
{
    public class Repository<T>: IRepository<T> where T : IPerson
    {
        private readonly DbCommandExecutor _commandExecutor;
        private readonly DbConnection _dbConnection;

        public Repository()
        {
            _dbConnection = DbConnection.GetInstance();
            _commandExecutor = new DbCommandExecutor(_dbConnection);
        }
            
        public void Add(T entity)
        {
            _commandExecutor.ExecuteCommand
                ($"INSERT INTO Persons (FirstName, SecondName, Age) VALUES ('{entity.FirstName}', '{entity.SecondName}', {entity.Age});");
        }
    }
}
