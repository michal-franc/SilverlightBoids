using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace SilverlightBoids.Logic.Styles
{
    public static class Colors
    {
        public static SolidColorBrush FleeEllipseBrush = new SolidColorBrush(Color.FromArgb(255, 0, 100, 200));



        private static IList<Color> ColonyColors = new List<Color>()
        {
            Color.FromArgb(255,0,255,0),
            Color.FromArgb(255,0,0,255),
            Color.FromArgb(255,255,0,0)
        };

        private static int _colonyColorCounter = 0;
        
        public static Color GetColor()
        {
            return ColonyColors[_colonyColorCounter++];          
        }   
    }
}
