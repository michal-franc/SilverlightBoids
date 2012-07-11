using System;

namespace Boids.Core.BoidAction
{
    public class BoidActionArrive : IBoidAction 
    {
        public int ArriveRadius { get; set; }

        public BoidActionArrive()
            : this(10)
        {
        }

        public BoidActionArrive(int arrivalRadius)
        {
            ArriveRadius = arrivalRadius;
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
