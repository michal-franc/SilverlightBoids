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
    public enum WorldObjectType
    {
        Ellipse,
        Square
    }

    public class WorldObject
    {

        public virtual int Size
        {
            get
            {
                return 3;
            }
        }

        public virtual SolidColorBrush ObjectColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255,255,255,255));
            }
        }

        public virtual WorldObjectType ObjectType
        {
            get
            {
                return WorldObjectType.Ellipse;
            }
        }
    
    }
}
