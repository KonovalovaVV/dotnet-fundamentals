using CsvDataBase.DataBase;
using CsvEnumberable.Test;
using CsvEnumerable;
using System;

namespace CsvDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            CsvEnumerable<Person> csvList = new CsvEnumerable<Person>("persons.csv");
            try
            {
                DbConnection dataBase = DbConnection.GetInstance();
                DbCommandExecutor commandExecutor = new DbCommandExecutor(dataBase);
                foreach (Person p in csvList)
                {
                    commandExecutor.ExecuteCommandAsync("INSERT INTO Persons (Person) VALUES ('" + p + "');");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            }
    }
}
