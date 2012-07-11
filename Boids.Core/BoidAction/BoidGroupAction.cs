using System;

namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;

    public class BoidGroupAction : IBoidAction
    {
        public IList<Boid> BoidGroup { protected get; set; }
        protected int boidId = 0;


        public BoidGroupAction(IList<Boid> boidGroup, int Id)
        {
            this.BoidGroup = boidGroup;
            boidId = Id;
        }

        public virtual Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
