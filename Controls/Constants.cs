using System.Drawing;
using System.Drawing.Drawing2D;

namespace TimeSands.Controls
{
    internal static class Constants
    {
        public static readonly Color FrameColor = Color.LightGray;
        public static readonly Pen FramePen = new Pen(FrameColor, 1);
        public static readonly Pen FramePenDash = new Pen(Constants.FrameColor, 1) { DashStyle = DashStyle.Dash };
    }
}
