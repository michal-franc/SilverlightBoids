using System.Collections.Generic;

namespace Boids.Core 
{
    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

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

        private  IList<IBoidAction> DefaultActionList
        {
            get
            {
                return new List<IBoidAction> {new BoidActionLookFor(new WorldObjectFood(2), _world), new BoidActionWander()};
            }
        }

        public virtual IList<IBoidAction> Actions 
        {
            get
            {
                if (_actions == null)
                {
                    _actions = DefaultActionList;
                }
                return _actions;
            }
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            Vector2 returnVector = Vector2.Zero;
            foreach (IBoidAction action in Actions)
            {
                returnVector = action.DoAction(dest, location, velocity, maxSpeed);

                if (returnVector.IsZero)
                    break;
            }

            return returnVector;
        }
    }
}
