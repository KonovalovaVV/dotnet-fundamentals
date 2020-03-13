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

            ILogger fileLogger = new FileLogger("logFile.txt");
            fileLogger.Error("some error");
            fileLogger.Warning("some warning");
            fileLogger.Error(new Exception("some exception"));
            fileLogger.Info("some info");

            ILogger dbLogger = new DbLogger("Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
                                            + "Integrated Security=true;");
            dbLogger.Error("some error");
            dbLogger.Warning("some warning");
            dbLogger.Error(new Exception("some exception"));
            dbLogger.Info("some info");
        }
    }
}
