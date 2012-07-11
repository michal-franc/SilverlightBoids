using System.Windows.Media;

namespace Boids.Core.WorldLogic
{
    public class WorldObjectFood : IWorldObject
    {

        private int _size;
        public int Size
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

        public SolidColorBrush ObjectColor
        {
            get
            {
                return new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            }
        }

        public WorldObjectType ObjectType
        {
            get
            {
                return WorldObjectType.Ellipse;
            }
        }
    }
}
