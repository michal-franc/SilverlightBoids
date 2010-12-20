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

namespace SilverlightBoids.Logic
{
    public class BoidActionSeek : IBoidAction
    {

        #region IBoidAction Members

        public Vector2 DoAction(Vector2 dest, Vector2 location,Vector2 velocity,int maxSpeed)
        {
            Vector2 newVector = Vector2.Normalize(Vector2.Subtract(dest, location)) * maxSpeed;
            return Vector2.Subtract(newVector, velocity);
        }

        #endregion
    }
}
