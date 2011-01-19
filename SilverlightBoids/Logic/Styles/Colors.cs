using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;R

        private static IList<Color> ColonyColors = new List<Color>()
        {
            Color.FromArgb(255,0,255,0),
            Color.FromArgb(255,0,0,255),
            Color.FromArgb(255,255,0,0)
        };


        private static int _colonyColorCounter = 0;

        public static Color GetColor()
        {
            return ColonyColors[_colonyColorCounter++ % 3];
        }
    }
}
