using System;

namespace CsvEnumerable
{
    public class Program
    {
        static void Main()
        {
            CsvEnumerable csvList = new CsvEnumerable("addresses.csv");
            foreach (string p in csvList)
                Console.WriteLine(p);
        }
    }
}
