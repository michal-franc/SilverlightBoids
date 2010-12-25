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

namespace SilverlightBoids.Boid
{
    public class Colony
    {
        public Point ColonyPosition { get; set; }

        public IList<BoidControl> Boids { get; set; }
        public Color Color { get; set; }
        public int BoidCounter 
        {
            get
            {
                if (Boids != null)
                    return this.Boids.Count;
                else
                    return 0;
            }
        }
    }
}
