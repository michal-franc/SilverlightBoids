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
using SilverlightBoids.Logic;

namespace SilverlightBoids
{
    public interface IBoidAction
    {
        Vector2 DoAction(Vector2 dest, Vector2 location,Vector2 velocity,int maxSpeed);
    }
}
