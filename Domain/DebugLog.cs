using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DebugLog : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine($"LOG {DateTime.Now}: {message}");
        }
    }
}
