using System.Windows.Controls;
using System.Windows.Shapes;
using Boids.Core;
using Boids.Core.WorldLogic;

namespace SilverlightBoids
{
    public partial class WorldObjectContainer : UserControl
    {
        private Vector2 _position;

        public IWorldObject ContainedObject { get; set; }

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


        public WorldObjectContainer(IWorldObject containedObject)
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
