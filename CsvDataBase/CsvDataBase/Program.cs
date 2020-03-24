using CsvDataBase.AppSettings;
using CsvEnumerable.Test;
using CsvDataBase.Repository;
using CsvEnumerable;
using System;
using LoggingProxy;

namespace CsvDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Person> repository = LoggingProxy<IRepository<Person>>.CreateInstance(new Repository<Person>());
            CsvEnumerable<Person> csvList
                = new CsvEnumerable<Person>(AppSettingsProvider.GetInstance().Settings.CsvFileName);
            try
            {
                foreach (Person p in csvList)
                {
                    repository.Add(p);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}
