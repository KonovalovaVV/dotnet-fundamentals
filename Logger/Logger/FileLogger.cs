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
            using StreamWriter streamWriter = new StreamWriter(FileName);
            streamWriter.WriteLine("Error occured: " + message);
            streamWriter.Close();
        }

        public void Error(Exception ex)
        {
            using StreamWriter streamWriter = new StreamWriter(FileName);
            streamWriter.WriteLine("Exception thrown: " + ex.Message);
            streamWriter.Close();
        }

        public void Warning(string message)
        {
            using StreamWriter streamWriter = new StreamWriter(FileName);
            streamWriter.WriteLine("Warning: " + message);
            streamWriter.Close();
        }

        public void Info(string message)
        {
            using StreamWriter streamWriter = new StreamWriter(FileName);
            streamWriter.WriteLine("Info: " + message);
            streamWriter.Close();
        }
    }
}