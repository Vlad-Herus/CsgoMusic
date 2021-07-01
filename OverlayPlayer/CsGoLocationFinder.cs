using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer
{
    static class CsGoLocationFinder
    {
      public  static string GetCsGoLocation()
        {
            string csgoPath = Process.GetProcesses()
                .Where(proc=>proc.ProcessName == "csgo" && proc.MainModule.FileName.EndsWith("csgo.exe")) 
                .First()
                .MainModule.FileName;
        
            return Path.GetDirectoryName(csgoPath);
        }
    }
}
