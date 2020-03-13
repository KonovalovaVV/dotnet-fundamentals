using System;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            ILogger consoleLogger = new ConsoleLogger();
            consoleLogger.Error("some error");
            consoleLogger.Warning("some warning");
            consoleLogger.Error(new Exception("some exception"));
            consoleLogger.Info("some info");
        }
    }
}
