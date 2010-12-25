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

namespace SilverlightBoids.WorldLogic
{
    public class WorldObjectFood : WorldObject
    {

        private int _size;
        public override int Size
        {
            get
            {
                return _size;
            }
        }

        public WorldObjectFood(int size) : base()
        {
            _size = size;
        }

        public override SolidColorBrush ObjectColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
        }

        public override WorldObjectType ObjectType
        {
            get
            {
                return WorldObjectType.Ellipse;
            }
        }
    }
}
