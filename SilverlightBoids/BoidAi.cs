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
using SilverlightBoids.Logic;
using SilverlightBoids.Logic.BoidAction;
using SilverlightBoids.WorldLogic;

namespace SilverlightBoids.Boid 
{
    public class BoidAi : IBoidAction
    {
        private int _boidID;
        private World _world;

        public BoidAi(int boidID,World world)
        {
            _boidID = boidID;
            _world = world;
        }

        private IList<IBoidAction> _actions;

        public virtual IList<IBoidAction> Actions 
        {
            get
            {
                if (_actions == null)
                {
                    _actions =  new List<IBoidAction>() { new BoidActionLookFor(new WorldLogic.WorldObjectFood(2), _world), new BoidActionWander() };
                }
                return _actions;
            }
        }

        #region IBoidAction Members

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            Vector2 returnVector = Vector2.Zero;
            foreach (IBoidAction action in Actions)
            {
                returnVector = action.DoAction(dest, location, velocity, maxSpeed);
                if (!returnVector.IsZero)
                {
                    return returnVector;
                }
            }

            return returnVector;

        }

        #endregion
    }
}
