using System;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            SimpleLogger defaultLogger = new SimpleLogger();
            defaultLogger.Error("some error");
            defaultLogger.Warning("some warning");
            defaultLogger.Error(new Exception("some exception"));
            defaultLogger.Info("some info");
            
            SimpleLogger dbLogger = new SimpleLogger(new DbLogger("Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
                                                       + "Integrated Security=true;"));
            dbLogger.Error("some error");
            dbLogger.Warning("some warning");
            dbLogger.Error(new Exception("some exception"));
            dbLogger.Info("some info");

            SimpleLogger fileLogger = new SimpleLogger(new FileLogger("logFile.txt"));
            fileLogger.Error("some error");
            fileLogger.Warning("some warning");
            fileLogger.Error(new Exception("some exception"));
            fileLogger.Info("some info");
        }
    }
}
