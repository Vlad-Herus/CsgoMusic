using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer.MenuItems
{
    class FolderItem : AMenuItem
    {
        public FolderItem(string folderPath)
        {
            Contract.Requires(Directory.Exists(folderPath));
            Caption = Path.GetFileName(folderPath);

            List<AMenuItem> subItems = new List<MenuItems.AMenuItem>();

            foreach (var folder in Directory.GetDirectories(folderPath))
            {
                subItems.Add(new FolderItem(folder));
            }

            foreach (var file in Directory.GetFiles(folderPath))
            {
                if (file.EndsWith(CsGoSongItem.WAV_EXTESION, StringComparison.CurrentCultureIgnoreCase))
                    subItems.Add(new CsGoSongItem(file));
                else if (file.EndsWith(CommandItem.CMD_EXTESION, StringComparison.CurrentCultureIgnoreCase))
                    subItems.Add(new CommandItem(file));
            }

            SubItems = subItems;
        }

        public override void Execute()
        {
        }
    }
}
