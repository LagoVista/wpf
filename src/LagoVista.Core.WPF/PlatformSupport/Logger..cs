using LagoVista.Core.PlatformSupport;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.Core.WPF.PlatformSupport
{
    public class Logger : ILogger
    {
        public void Log(LogLevel level, string area, string message, params KeyValuePair<string, string>[] args)
        {
            Debug.WriteLine("=================================================");
            Debug.WriteLine("LEVEL      : " + level);
            Debug.WriteLine("AREA       : " + area);
            Debug.WriteLine("Message    : " + message);
            Debug.WriteLine("=================================================");
        }

        public void LogException(string area, Exception ex, params KeyValuePair<string, string>[] args)
        {
            Debug.WriteLine("AREA       : " + area);
            Debug.WriteLine("Exception  : " + ex.Message);
            if (!String.IsNullOrEmpty(ex.StackTrace))
                Debug.WriteLine(ex.StackTrace);
            else
                Debug.Write("NO STACK TRACE");
        }

        public void SetKeys(params string[] args)
        {
        }

        public void SetUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void TrackEvent(string message, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
