using System;

namespace CsvEnumerable
{
    public class Program
    {
        static void Main()
        {
            CsvEnumerable csvList = new CsvEnumerable("addresses.csv");
            Console.WriteLine("----First foreach----");
            foreach (string p in csvList)
                Console.WriteLine(p);
            Console.WriteLine("----Second foreach----");
            foreach (string p in csvList)
                Console.WriteLine(p);
        }
    }
}
