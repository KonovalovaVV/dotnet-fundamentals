using System;
using Logger;

namespace LoggingProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic consoleLogger = LoggingProxy<ILogger>.CreateInstance(new ConsoleLogger());
            consoleLogger.Error("fake error");
            consoleLogger.Warning("fake warning");
            consoleLogger.Error(new Exception("fake exception"));
            consoleLogger.Info("some info");

            dynamic fileLogger = LoggingProxy<ILogger>.CreateInstance(new FileLogger("output.txt"));
            fileLogger.Error("fake error");
            fileLogger.Warning("fake warning");
            fileLogger.Error(new Exception("fake exception"));
            fileLogger.Info("some info");
        }
    }
}
