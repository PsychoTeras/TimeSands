using System.Drawing;

namespace TimeSands.Resources
{
    internal static class Resources
    {
        public static Image GreyBall { get; }
        public static Image GreenBall { get; }
        public static Image YellowBall { get; }
        public static Image RedBall { get; }

        static Resources()
        {
            GreyBall = Properties.Resources.bullet_ball_glass_grey;
            GreenBall = Properties.Resources.bullet_ball_glass_green;
            YellowBall = Properties.Resources.bullet_ball_glass_yellow;
            RedBall = Properties.Resources.bullet_ball_glass_red;
        }
    }
}
