﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
            if(!Directory.Exists(LogBatse)){
                Directory.CreateDirectory(LogBatse);
            }
            string Timestamp = DateTime.Now.ToString("YYYYMMDD");
            string fileName = Path.Combine(LogBatse, Timestamp);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.WriteLine($"{DateTime.Now.ToString("YYYYMMDDHHmmSS")} {message}");
                streamWriter.Close();
            }
        }
    }
}