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

namespace SilverlightBoids.Logic.Styles
{
    using Boids.Core;

    public partial class FleeEllipse : UserControl
    {
        private Point _position;

        public Point Position
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
                    this.SetValue(Canvas.LeftProperty, (double)value.X - (SimulationSettings.FleeRadius / 2));
                    this.SetValue(Canvas.TopProperty, (double)value.Y - (SimulationSettings.FleeRadius / 2));
                }
            }
            
        }

        public FleeEllipse()
        {
            InitializeComponent();
            Ellipse.Stroke = Colors.FleeEllipseBrush;
            this.Width = SimulationSettings.FleeRadius;
            this.Height = SimulationSettings.FleeRadius;
        }
    }
}
