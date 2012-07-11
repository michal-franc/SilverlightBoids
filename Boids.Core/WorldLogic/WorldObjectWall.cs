using System;
using System.Windows.Media;

namespace Boids.Core.WorldLogic
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
