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
    public partial class WorlfObjectContainer : UserControl
    {
        private Vector2 _position;

        public WorldObject ContainedObject { get; set; }

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


        public WorlfObjectContainer(WorldObject containedObject)
        {
            InitializeComponent();
            Shape shape = null;
            if (containedObject.ObjectType == WorldObjectType.Ellipse)
            {
                shape = new Ellipse();
            }
            else if (containedObject.ObjectType == WorldObjectType.Square)
            {
                shape = new Rectangle();
            }

            if (shape != null)
            {
                shape.Width = containedObject.Size;
                shape.Height = containedObject.Size;

                ContainedObject = containedObject;
                shape.Fill = containedObject.ObjectColor;
                LayoutRoot.Children.Add(shape);
            }
        }
    }
}
