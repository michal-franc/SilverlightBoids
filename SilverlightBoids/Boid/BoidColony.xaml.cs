using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightBoids.Logic;

namespace SilverlightBoids.Boid
{
    public partial class BoidColony : UserControl
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                if (value.X >= 0 && value.Y >= 0)
                {
                    this.SetValue(Canvas.LeftProperty, (double)value.X);
                    this.SetValue(Canvas.TopProperty, (double)value.Y);
                }
            }
        }

        public IList<BoidControl> Boids { get; set; }

        public Color ColonyColor { get; set; }

        public BoidColony(Color color,Vector2 position)
        {
            InitializeComponent();

            Position = position;
            ColonyColor = color;
            Rect.Fill = new SolidColorBrush(color);
        }
    }
}
