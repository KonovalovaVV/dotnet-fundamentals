using System;

namespace Logger
{
    public class ConsoleLogger : BaseLogger
    {
        protected override void Write(LogLevel level, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            Console.WriteLine($"{DateTime.Now}: {level.ToString()}");
            Console.WriteLine(message);
        }
    }
}
