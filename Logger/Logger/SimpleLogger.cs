using System;

namespace Logger
{
    public class SimpleLogger: ILogger
    {
        private readonly ILogger _logger;

        public SimpleLogger()
        {
            _logger = new ConsoleLogger();
        }
        
        public SimpleLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Error(Exception ex)
        {
            _logger.Error(ex);
        }

        public void Warning(string message)
        {
            _logger.Warning(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }
    }
}
