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

namespace SilverlightBoids.Logic.BoidAction
{
    public class BoidActionLookFor : IBoidAction
    {
        private BoidActionSeek _seek = new BoidActionSeek();
        private BoidActionNoAction _noAction = new BoidActionNoAction();
        private World _world;

        private IWorldObject _objectToLookFor;
        private int _radius = 10;

        public BoidActionLookFor(IWorldObject objectToLook,World world)
        {
            _objectToLookFor = objectToLook;
            _world = world;
        }
        #region IBoidAction Members

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            Vector2 newDest = _world.LookFor(_objectToLookFor, location,_radius);
            if (newDest.IsZero)
            {
                return _noAction.DoAction(dest, location, velocity, maxSpeed);
            }
            else
                return _seek.DoAction(newDest, location, velocity, maxSpeed);
        }

        #endregion
    }
}
