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
        public FileLogger(string logName) : base(logName)
        {

        }
        public override void Log(string message)
        {
            try
            {
                string prefix = string.IsNullOrEmpty(this.Name) ? string.Empty : $" - {this.Name}";
                string logBase = ConfigurationManager.AppSettings["log-folder"];
                if (!string.IsNullOrEmpty(logBase))
                {
                    logBase = $"{logBase}{prefix}";
                }
                if (!Directory.Exists(logBase))
                {
                    Directory.CreateDirectory(logBase);
                }
                string Timestamp = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
                string fileName = $"{Path.Combine($"{logBase}", Timestamp)}.log";
                using (StreamWriter streamWriter = new StreamWriter(fileName, true))
                {
                    streamWriter.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss", DateTimeFormatInfo.InvariantInfo)} {message}");
                    streamWriter.Close();
                }
            }
            catch { }
        }

    }
}
