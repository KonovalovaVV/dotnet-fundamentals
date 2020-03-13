using System;

namespace Logger
{
    public class ConsoleLogger: ILogger
    {
        public void Error(string message)
        {
            ShowMessage(Titles.Error + message);
        }

        public void Error(Exception ex)
        {
            ShowMessage(Titles.Exception + ex.Message);
        }

        public void Warning(string message)
        {
            ShowMessage(Titles.Warning + message);
        }

        public void Info(string message)
        {
            ShowMessage(Titles.Info + message);
        }

        private void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
