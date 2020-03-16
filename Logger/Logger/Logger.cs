namespace Logger
{
    public class Logger
    {
        public ILogger Logger { get; set; }

        public Logger()
        {
            logger = new ConsoleLogger();
        }
        
        public Logger(ILogger _logger)
        {
            logger = _logger;
        }
    }
}
