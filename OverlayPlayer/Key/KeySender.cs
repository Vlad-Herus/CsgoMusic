using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayPlayer.Key
{
    static class KeySender
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        const int KEYEVENTF_KEYUP = 0x0002; //Key up flag

        public static void SendKeySmart(Keys key)
        {
            int delay = new Random((int)DateTime.Now.Ticks).Next(100, 200);

            keybd_event((byte)key, 41, KEYEVENTF_EXTENDEDKEY, 0);
            Thread.Sleep(delay);
            keybd_event((byte)key, 41, KEYEVENTF_KEYUP, 0);
        }

        public static void SendKeys(string keys)
        {
            keys = keys.Replace("+", "{+}");
            System.Windows.Forms.SendKeys.Send(keys);
        }
    }
}
