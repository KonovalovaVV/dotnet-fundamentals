using CsvEnumerable.Test;

namespace CsvDataBase.Repository
{
    public interface IRepository<T> where T: IPerson
    {
        void Add(T entity);
    }
}
