using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public readonly string FileName;

        public FileLogger(string fileName)
        {
            FileName = fileName;
        }

        protected override void Write(LogLevel level, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }
            
            byte[] buff = Encoding.Default.GetBytes($"{DateTime.Now}: {level.ToString()}" + message);
            using FileStream fs = new FileStream(FileName, FileMode.Append, FileAccess.Write);
            fs.Write(buff, 0, buff.Length);
            fs.Flush();
            fs.Close();
        }
    }
}