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

namespace SilverlightBoids.WorldLogic
{
    public partial class RockObject : UserControl, IWorldObject
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

        public RockObject(Vector2 positionOnMap)
        {
            InitializeComponent();

            Position = positionOnMap;
        }

        public RockObject(Point positionOnMap)
            : this(new Vector2(positionOnMap))
        {
        }

        public int Size
        {
            get { return (int)RockRectangle.Width; }
        }

        public SolidColorBrush ObjectColor
        {
            get { return RockRectangle.Fill as SolidColorBrush; }
        }

        public WorldObjectType ObjectType
        {
            get { return WorldObjectType.Square; }
        }
    }
}
