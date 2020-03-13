using System;

namespace Logger
{
    public interface ILogger
    {
        void Error(string message)
        {
            Console.WriteLine("Error occured: " + message);
        }

        public void Error(Exception ex)
        {
            Console.WriteLine("Exception thrown: " + ex.Message);
        }

        public void Warning(string message)
        {
            Console.WriteLine("Warning: " + message);
        }

        public void Info(string message)
        {
            Console.WriteLine("Info: " + message);
        }
    }
}
