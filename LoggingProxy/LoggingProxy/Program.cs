using LoggingProxy.Logger;

namespace LoggingProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic logger = new LoggingProxy<ILogger>(new ConsoleLogger());
            logger.Error("fake error");
        }
    }
}
