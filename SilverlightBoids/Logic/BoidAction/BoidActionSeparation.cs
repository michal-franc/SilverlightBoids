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
using SilverlightBoids.WorldLogic;

namespace SilverlightBoids.Logic
{
    public class BoidActionSeparation : IBoidAction
    {
        private World _world;
        private int _separationRadius = 3;
        private int _id;

        private BoidActionFlee _flee;
        private BoidActionWander _wander;


        #region IBoidAction Members

        public BoidActionSeparation(World world,int id)
        {
            _world = world;
            _id = id;
            _flee = new BoidActionFlee();
            _wander = new BoidActionWander(id);
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            foreach (BoidControl boid in _world.BoidList)
            {
                if (boid.ID != _id)
                {
                    if (Vector2.Subtract(location, boid.Position).Length() < _separationRadius)
                    {
                        return _flee.DoAction(boid.Position, location, velocity, maxSpeed);
                    }
                }
            }
            return _wander.DoAction(dest, location, velocity, maxSpeed);
        }

        #endregion
    }
}
