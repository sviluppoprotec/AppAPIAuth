using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class LogBase
    {
        protected string Name;
        protected LogBase(string logName){
            this.Name = logName;
        }
        public abstract void Log(string message);
    }
}
