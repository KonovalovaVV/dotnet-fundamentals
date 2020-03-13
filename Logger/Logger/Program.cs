using System;

namespace Logger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logger defaultLogger = new Logger();
            defaultLogger.logger.Error("some error");
            defaultLogger.logger.Warning("some warning");
            defaultLogger.logger.Error(new Exception("some exception"));
            defaultLogger.logger.Info("some info");
            
            Logger dbLogger = new Logger(new DbLogger("Data Source=MSSQL1;Initial Catalog=AdventureWorks;"
                                                       + "Integrated Security=true;"));
            dbLogger.logger.Error("some error");
            dbLogger.logger.Warning("some warning");
            dbLogger.logger.Error(new Exception("some exception"));
            dbLogger.logger.Info("some info");

            Logger fileLogger = new Logger(new FileLogger("logFile.txt"));
            fileLogger.logger.Error("some error");
            fileLogger.logger.Warning("some warning");
            fileLogger.logger.Error(new Exception("some exception"));
            fileLogger.logger.Info("some info");
        }
    }
}
