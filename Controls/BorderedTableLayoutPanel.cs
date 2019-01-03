using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TimeSands.Controls
{
    public sealed class BorderedTableLayoutPanel : TableLayoutPanel
    {
        private bool _drawGridLines = true;

        [Browsable(true), DefaultValue(true)]
        public bool DrawGridLines
        {
            get { return _drawGridLines; }
            set
            {
                _drawGridLines = value;
                Invalidate();
            }
        }

        public BorderedTableLayoutPanel()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            e.Graphics.DrawRectangle(Constants.FramePen, r);
        }

        protected override void OnCellPaint(TableLayoutCellPaintEventArgs e)
        {
            if (_drawGridLines && e.Row > 0)
            {
                e.Graphics.DrawLine(Constants.FramePenDash, e.CellBounds.Left, e.CellBounds.Top,
                    e.CellBounds.Left + e.CellBounds.Width - 1, e.CellBounds.Top);
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            Invalidate(false);
            base.OnResize(eventargs);
        }
    }
}
