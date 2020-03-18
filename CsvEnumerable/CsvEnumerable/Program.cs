using System;

namespace CsvEnumerable
{
    public class Program
    {
        static void Main(string[] args)
        {
            CsvEnumerable csvEnumerable = new CsvEnumerable("addresses.csv");
            foreach(var record in csvEnumerable)
            {
                Console.WriteLine(record + '*');
            }
        }
    }
}
