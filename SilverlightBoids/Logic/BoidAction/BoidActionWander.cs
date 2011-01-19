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
        private static int _seed = 1;
        private BoidActionSeek _seek = new BoidActionSeek();
        Random generator;

        private Nullable<Vector2> newLocation = null;
        private int _wanderFov = 10;
        private int _wanderJitter = 20;
        private int _wanderRadius = 10;

        public BoidActionWander()
        {
            generator = new Random(_seed);
            _seed++;
        }


        #region IBoidAction Members
        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            //1. First Random Vector to start the move
            if (!newLocation.HasValue)
            {
                return RandomMove(location, velocity, maxSpeed);
            }
            else
            {
                Vector2 heading = Vector2.Normalize(velocity);
                dest = new Vector2(generator.Next(-_wanderJitter, _wanderJitter),generator.Next(-_wanderJitter, _wanderJitter));
                dest = Vector2.Normalize(dest);
                dest *= _wanderRadius / 2;
                Vector2 circleCenterM = new Vector2((heading.X * _wanderRadius) + location.X,
                         (heading.Y * _wanderRadius) + location.Y);
                Vector2 pointOnCircle = new Vector2(circleCenterM.X + dest.X,
                                            circleCenterM.Y + dest.Y);
                Vector2 returnVector = Vector2.Subtract(pointOnCircle, location);
                if (returnVector.IsNan)
                    return RandomMove(location, velocity, maxSpeed);
                else
                    return returnVector;

            }
        }

        private Vector2 RandomMove(Vector2 location,Vector2 velocity,int maxSpeed)
        {
            int oldX = (int)Convert.ToDouble(location.X);
            int oldY = (int)Convert.ToDouble(location.Y);
            
            int newX = generator.Next(oldX - _wanderFov, oldX + _wanderFov);
            int newY = generator.Next(oldY - _wanderFov, oldY + _wanderFov);
            newLocation = new Vector2(newX, newY);
            return _seek.DoAction(newLocation.Value, location, velocity, maxSpeed);
        }
        #endregion
    }
}
