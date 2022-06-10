using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
   public sealed class Log : ILogger
    {

        

        private static readonly Lazy<Log> instance = new Lazy<Log>( () => new Log());


        public static  Log GetInstance
        {
            get { return instance.Value ; }
           
        }

        private Log()
        {
           
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilepath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using(StreamWriter writer = new StreamWriter(logFilepath,true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
