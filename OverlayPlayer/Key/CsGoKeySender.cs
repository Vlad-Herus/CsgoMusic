using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer.Key
{
    class CsGoKeySender
    {
        public static void SendCommands(params string[] commands)
        {
            SendCommands(commands as IEnumerable<string>);
        }

        public static void SendCommands(IEnumerable<string> commands)
        {
            KeySender.SendKeySmart(System.Windows.Forms.Keys.Oemtilde);
            foreach (var line in commands)
                KeySender.SendKeys(line + "{ENTER}");
            KeySender.SendKeySmart(System.Windows.Forms.Keys.Oemtilde);
        }
    }
}
