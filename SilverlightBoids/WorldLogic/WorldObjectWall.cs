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
    public class WorldObjectWall : IWorldObject
    {
        public SolidColorBrush ObjectColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255,255,100,0));
            }
        }

        public WorldObjectType ObjectType
        {
            get
            {
                return WorldObjectType.Square;
            }
        }

        public int Size
        {
            get { throw new NotImplementedException(); }
        }
    }
}
