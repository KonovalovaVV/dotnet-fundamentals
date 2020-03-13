using System;

namespace Logger
{
    public abstract class BaseLogger : ILogger
    {
        public void Info(string message)
        {
            Write(LogLevel.Info, message);
        }

        public void Warning(string message)
        {
            Write(LogLevel.Warning, message);
        }

        public void Error(string message)
        {
            Write(LogLevel.Error, message);
        }

        public void Error(Exception ex)
        {
            Write(LogLevel.Error, $"Type: {ex.GetType()} Message: {ex.Message}");
        }

        protected abstract void Write(LogLevel level, string message);
    }
}
