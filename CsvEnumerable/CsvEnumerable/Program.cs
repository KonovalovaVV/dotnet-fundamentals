using System;
using CsvEnumerable.DataBase;

namespace CsvEnumerable
{
    public class Program
    {
        static void Main()
        {
            CsvEnumerable<string> csvList = new CsvEnumerable<string>("addresses.csv");
            try
            {
                DbConnection dataBase = DbConnection.GetInstance();
                DbCommandExecutor commandExecutor = new DbCommandExecutor(dataBase);
                foreach (string p in csvList)
                {
                    commandExecutor.ExecuteCommandAsync("INSERT INTO Addresses (Address) VALUES ('" + p + "');");
                }
            }
            catch (Exception ex)
            {
                 Console.Write(ex);
            }
            Console.WriteLine("----Second foreach----");
            foreach (string p in csvList)
                Console.WriteLine(p);
        }
    }
}
