using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer
{
    class Log
    {
        public static void TraceTime(string msg)
        {
            var time = System.DateTime.Now;
            var timeString = time.Minute + ":" + time.Second + ":" + time.Millisecond;
            if (!string.IsNullOrEmpty(msg))
                System.Diagnostics.Trace.WriteLine(timeString + "  " + msg);
        }

    }
}
