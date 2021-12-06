using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogger : LogBase
    {
        public override void Log(string message)
        {
            string LogBatse = ConfigurationManager.AppSettings["log-folder"];
            if (!Directory.Exists(LogBatse))
            {
                Directory.CreateDirectory(LogBatse);
            }
            string Timestamp = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            string fileName = $"{Path.Combine(LogBatse, Timestamp)}.log";
            using (StreamWriter streamWriter = new StreamWriter(fileName, true))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss", DateTimeFormatInfo.InvariantInfo)} {message}");
                streamWriter.Close();
            }
        }
    }
}
