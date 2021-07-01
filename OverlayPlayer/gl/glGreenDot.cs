using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverlayPlayer.gl
{
    class glGreenDot : OpenGlDraw
    {
        double mCenterX;
        double mCenterY;

        const int DOT_RADI = 3;

        public glGreenDot()
        {
            var bounds = Screen.PrimaryScreen.Bounds;
            mCenterX = (bounds.Left + bounds.Right) / 2;
            mCenterY = (bounds.Top + bounds.Bottom) / 2;
        }


        protected override void Render(Graphics graphics, Form form)
        {
            var offset = form.PointToScreen(new Point(0, 0));
            SolidBrush b = new SolidBrush(Color.Green);
            graphics.FillRectangle(b, new Rectangle((int)mCenterX - DOT_RADI - offset.X, (int)mCenterY - DOT_RADI - offset.Y, DOT_RADI * 2, DOT_RADI * 2));
        }
    }
}
