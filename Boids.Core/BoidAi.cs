namespace Boids.Core 
{
    using System.Collections.Generic;

    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

    public class BoidAi : IBoidAction
    {
        private int boidID;
        private World world;
        private IList<IBoidAction> actions;

        public BoidAi(int boidID, World world)
        {
            this.boidID = boidID;
            this.world = world;
        }

        public virtual IList<IBoidAction> Actions 
        {
            get
            {
                if (this.actions == null)
                {
                    this.actions = this.DefaultActionList;
                }

                return this.actions;
            }
        }

        private IList<IBoidAction> DefaultActionList
        {
            get
            {
                return new List<IBoidAction> { new BoidActionLookFor(new WorldObjectFood(2), this.world), new BoidActionWander() };
            }
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            Vector2 returnVector = Vector2.Zero;
            foreach (var action in this.Actions)
            {
                returnVector = action.DoAction(dest, location, velocity, maxSpeed);

                if (returnVector.IsZero)
                {
                    break;
                }
            }

            return returnVector;
        }
    }
}
