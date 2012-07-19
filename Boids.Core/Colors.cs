namespace Boids.Core
{
    using System.Collections.Generic;
    using System.Windows.Media;

    public static class Colors
    {
        private static readonly IList<Color> ColonyColors = new List<Color>()
        {
            Color.FromArgb(255,0,255,0),
            Color.FromArgb(255,0,0,255),
            Color.FromArgb(255,255,0,0)
        };

        private static int colonyColorCounter;

        public static SolidColorBrush FleeEllipseBrush
        {
            get { return new SolidColorBrush(Color.FromArgb(255, 0, 100, 200)); }
        }

        public static Color Yellow
        {
            get { return Color.FromArgb(255, 0, 255, 255); }
        }

        public static Color GetNextColor()
        {
            return ColonyColors[colonyColorCounter++ % 3];
        }
    }
}
