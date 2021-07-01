using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlayPlayer.MenuItems
{
    abstract class AMenuItem
    {
        public string Caption { get; set; }

        public IEnumerable<AMenuItem> SubItems { get; protected set; }

        public abstract void Execute();
    }
}
