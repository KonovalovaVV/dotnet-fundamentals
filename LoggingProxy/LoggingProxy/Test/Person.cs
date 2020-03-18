using System;

namespace LoggingProxy.Test
{
    class Person: IPerson
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age = 0;

        public int GetAge()
        {
            return Age;
        }

        public void SetAge(int age)
        {
            try
            {
                if (age <= 0)
                    throw new ArgumentException("Invalid age.");
                Age = age;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SetName(string firstName, string secondName)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName))
                    throw new ArgumentException("Invalid first name.");
                if (string.IsNullOrEmpty(secondName))
                    throw new ArgumentException("Invalid second name.");
                FirstName = firstName;
                SecondName = secondName;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
