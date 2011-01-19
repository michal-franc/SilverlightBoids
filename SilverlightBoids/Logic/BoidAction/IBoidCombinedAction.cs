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
using System.Collections.Generic;

namespace SilverlightBoids.Logic.BoidAction
{
    public interface IBoidCombinedAction : IBoidAction
    {
        Vector2 CombineActions(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed, params IBoidAction[] actions);
    }
}
