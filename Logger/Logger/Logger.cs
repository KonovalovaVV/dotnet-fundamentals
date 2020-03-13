namespace Logger
{
    public class Logger
    {
        public ILogger logger { get; set; }

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
