using System;
using CsvEnumberable.Test;

namespace CsvEnumerable
{
    public class Program
    {
        static void Main()
        {
            CsvEnumerable<Person> csvList = new CsvEnumerable<Person>("persons.csv");
            foreach (Person p in csvList)
                Console.WriteLine(p.ToString());
        }
    }
}
