using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer.MenuItems
{
    class CommandItem : AMenuItem
    {
        public const string CMD_EXTESION = "cmd";
        IEnumerable<string> mCommands = Enumerable.Empty<string>();

        public CommandItem(string cmdPath)
        {
            Contract.Requires(File.Exists(cmdPath));
            Contract.Requires(cmdPath.EndsWith(CMD_EXTESION, StringComparison.CurrentCultureIgnoreCase));

            SubItems = Enumerable.Empty<AMenuItem>();
            Caption = Path.GetFileNameWithoutExtension(cmdPath);
            mCommands = File.ReadAllLines(cmdPath);
        }

        public override void Execute()
        {
            Key.CsGoKeySender.SendCommands(mCommands);
        }
    }
}
