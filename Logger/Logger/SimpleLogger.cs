namespace Logger
{
    public class SimpleLogger
    {
        public ILogger Logger { get; set; }

        public SimpleLogger()
        {
            Logger = new ConsoleLogger();
        }
        
        public SimpleLogger(ILogger _logger)
        {
            Logger = _logger;
        }
    }
}
