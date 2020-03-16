using System;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            SimpleLogger defaultLogger = new SimpleLogger();
            defaultLogger.Logger.Error("some error");
            defaultLogger.Logger.Warning("some warning");
            defaultLogger.Logger.Error(new Exception("some exception"));
            defaultLogger.Logger.Info("some info");
            
            SimpleLogger dbLogger = new SimpleLogger(new DbLogger("Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
                                                       + "Integrated Security=true;"));
            dbLogger.Logger.Error("some error");
            dbLogger.Logger.Warning("some warning");
            dbLogger.Logger.Error(new Exception("some exception"));
            dbLogger.Logger.Info("some info");

            SimpleLogger fileLogger = new SimpleLogger(new FileLogger("logFile.txt"));
            fileLogger.Logger.Error("some error");
            fileLogger.Logger.Warning("some warning");
            fileLogger.Logger.Error(new Exception("some exception"));
            fileLogger.Logger.Info("some info");
        }
    }
}
