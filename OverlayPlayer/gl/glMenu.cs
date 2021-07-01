using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OverlayPlayer.MenuItems;
using System.Windows.Forms;

namespace OverlayPlayer.gl
{
    class glMenu : OpenGlDraw
    {
        int mYOffset = 100;
        int mXOffset = 50;
        IEnumerable<AMenuItem> mItems;
        object mItemsLock = new object();

        Font TextFont
        {
            get
            {
                var font = new Font(SystemFonts.DefaultFont.FontFamily, 22, FontStyle.Bold);
                return font;
            }
        }

        Brush TextBrush
        {
            get
            {
                return Brushes.Yellow;
            }
        }

        public IEnumerable<AMenuItem> Items
        {
            get
            {
                return mItems;
            }
        }


        public glMenu(IEnumerable<AMenuItem> items)
        {
            SetItems(items);
        }

        public void SetItems(IEnumerable<AMenuItem> items)
        {
            lock (mItemsLock)
                mItems = items;
        }

        protected override void Render(Graphics graphics, Form form)
        {
            lock (mItemsLock)
            {
                float currentYOffset = mYOffset;
                int currentId = 1;
                foreach (var item in mItems)
                {
                    string text = $"{currentId}. { item.Caption}";
                    graphics.DrawString(text, TextFont, TextBrush, new PointF(mXOffset, currentYOffset));
                    currentYOffset += graphics.MeasureString(text, TextFont).Height;
                    currentId++;
                }
            }
        }
    }
}
