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
    abstract class OpenGlDraw : IDisposable
    {
        Guid mRendererId;

        public OpenGlDraw()
        {
            mRendererId = HiddenForm.Instance.RegisterHandler(Render);
        }

        protected abstract void Render(Graphics graphics, Form form);

        public void Dispose()
        {
            HiddenForm.Instance.RemoveHandler(mRendererId);
        }
    }
}
