namespace CsvDataBase.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(int id);
    }
}
