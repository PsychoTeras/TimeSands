using System;
using System.Windows.Forms;

namespace TimeSands.Controls
{
    public sealed class HorizontalDivider : Control
    {
        public HorizontalDivider()
        {
            DoubleBuffered = true;
            Height = 1;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Constants.FramePen, e.ClipRectangle.Left, e.ClipRectangle.Top,
                e.ClipRectangle.Left + e.ClipRectangle.Width, e.ClipRectangle.Top);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            Invalidate(false);
            base.OnResize(eventargs);
        }
    }
}
