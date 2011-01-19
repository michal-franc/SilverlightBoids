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

namespace SilverlightBoids.Logic.BoidAction
{
    public class BoidActionArrive : IBoidAction 
    {
        public int ArriveRadius { get; set; }

        public BoidActionArrive()
            : this(10)
        {
        }

        public BoidActionArrive(int arrivaRadius)
        {
            ArriveRadius = arrivaRadius;
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            Vector2 toTarget = Vector2.Subtract(dest, location);
            double distance = toTarget.Length();
            if (distance > 0)
            {
                double speed = maxSpeed * (distance / ArriveRadius);
                speed = Math.Min(speed, maxSpeed);
                Vector2 desired_V = toTarget * (float)(speed / distance);
                return Vector2.Subtract(desired_V, velocity);
            }
            else
                return new Vector2(0, 0);
        }
    }
}
