using System;
using System.Drawing;
using System.Windows.Forms;

namespace TimeSands.Controls
{
    public sealed class BorderedPanel : Panel
    {
        public BorderedPanel()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Constants.FramePen, r);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            Invalidate(false);
            base.OnResize(eventargs);
        }
    }
}
