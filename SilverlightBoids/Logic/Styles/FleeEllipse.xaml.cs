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
                    this.SetValue(Canvas.LeftProperty, (double)value.X - (Settings.FleeRadius / 2));
                    this.SetValue(Canvas.TopProperty, (double)value.Y - (Settings.FleeRadius / 2));
                }
            }
            
        }

        public FleeEllipse()
        {
            InitializeComponent();
            Ellipse.Stroke = Logic.Styles.Colors.FleeEllipseBrush;
            this.Width = Logic.Settings.FleeRadius;
            this.Height = Logic.Settings.FleeRadius;
        }
    }
}
