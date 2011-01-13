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
