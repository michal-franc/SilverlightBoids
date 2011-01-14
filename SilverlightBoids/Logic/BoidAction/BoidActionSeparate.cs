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
    public class BoidActionSeparate : IBoidAction
    {
        private BoidControl _boid;
        private IList<BoidControl> _boidList;

        public BoidActionSeparate(BoidControl boid, IList<BoidControl> boidList)
        {
            _boidList = new List<BoidControl>();
            _boid = boid;
            _boidList = boidList;
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            int j = 0;
            Vector2 separationForce = new Vector2(0);
            Vector2 averageDirection = new Vector2(0);
            Vector2 distance = new Vector2(0);
            for (int i = 0; i < _boidList.Count; i++)
            {
                distance = Vector2.Subtract(location, _boidList[i].Position);
                if (Vector2.Length(distance) < 100 && _boidList[i] != _boid)
                {
                    j++;
                    separationForce += Vector2.Subtract(location, _boidList[i].Position);
                    separationForce = Vector2.Normalize(separationForce);
                    separationForce = Vector2.Multiply(separationForce, 1 / .7f);
                    averageDirection = Vector2.Add(averageDirection, separationForce);
                }
            }
            if (j == 0)
            {
                return Vector2.Zero;
            }
            else
            {
                return averageDirection;
            }
        }
    }
}
