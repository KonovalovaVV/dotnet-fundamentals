using LoggingProxy.Test;

namespace LoggingProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IPerson person = LoggingProxy<IPerson>.CreateInstance(new Person());
            person.FirstName = "Pavel";
            person.SecondName = "Ivanov";
            person.SetAge(30);
            person.SetName("Maria", "Pavlova");
        }
    }
}
