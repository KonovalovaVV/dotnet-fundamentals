using System;

namespace Logger
{
    public interface ILogger
    {
        public void Error(string message);

        public void Error(Exception ex);

        public void Warning(string message);

        public void Info(string message);
    }
}
