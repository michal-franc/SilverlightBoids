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
    public class BoidActionWander : IBoidAction
    {
        private BoidActionSeek _seek = new BoidActionSeek();
        private Nullable<Vector2> newLocation = null;
        private int _wanderFov = 10;

        #region IBoidAction Members

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            if (!newLocation.HasValue || Vector2.Subtract(location, newLocation.Value).Length() <= 2)
            {
                Random generator = new Random(DateTime.Now.Millisecond + DateTime.Now.Day);
                int oldX = Convert.ToInt32(location.X);
                int oldY = Convert.ToInt32(location.Y);

                int newX =+ generator.Next(oldX - _wanderFov, oldX + _wanderFov);
                int newY =+ generator.Next(oldY - _wanderFov, oldY + _wanderFov);
                newLocation= new Vector2(newX, newY);
            }

            return _seek.DoAction(newLocation.Value, location, velocity, maxSpeed);
        }

        #endregion
    }
}
