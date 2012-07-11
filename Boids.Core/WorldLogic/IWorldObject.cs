using System.Windows.Media;

namespace Boids.Core.WorldLogic
{
    public enum WorldObjectType
    {
        Ellipse,
        Square,
        Irregular
    }

    public interface IWorldObject
    {
        int Size { get; }
        SolidColorBrush ObjectColor { get; }
        WorldObjectType ObjectType { get; }
    }
}
