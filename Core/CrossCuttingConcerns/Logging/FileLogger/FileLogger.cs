using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Core.CrossCuttingConcerns.Logging
{

    namespace Core.CrossCuttingConcerns.Logging.FileLogger
    {
        public class FileLogger : ILoggerService
        {
            private readonly string _logFile = "logs.txt";

            public void Log(LogDetail logDetail)
            {
                var logText = JsonConvert.SerializeObject(logDetail);
                File.AppendAllText(_logFile, logText + Environment.NewLine);
            }
        }
    }

}
