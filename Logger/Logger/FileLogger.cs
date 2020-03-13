using System;
using System.IO;

namespace Logger
{
    public class FileLogger : ILogger
    {
        public readonly string FileName;

        public FileLogger(string fileName)
        {
            FileName = fileName;
        }

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
            using StreamWriter streamWriter = new StreamWriter(FileName);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }
    }
}