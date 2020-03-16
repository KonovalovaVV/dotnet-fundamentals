using System;
using LoggingProxy.Logger;

namespace LoggingProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic person = new LoggingProxy<ILogger>();
            person.Name = "Ivan";
            person.Age = 43;
            Func<int, int> Incr = delegate (int x) { person.Age += x; return person.Age; };
            person.IncrementAge = Incr;
            person.IncrementAge(6);
        }
    }
}
