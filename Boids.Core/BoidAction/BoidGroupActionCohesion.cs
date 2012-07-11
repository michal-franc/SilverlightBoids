namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;

    public class BoidGroupActionCohesion : BoidGroupAction
    {
        private int cohesionRange=50;

        public BoidGroupActionCohesion(IList<Boid> group, int Id)
            : base(group, Id)
        {

        }

        public override Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
                int j = 0;
                Vector2 averagePosition = new Vector2(0);
                Vector2 distance = new Vector2(0);
                foreach (Boid boid in this.BoidGroup)
                {
                    distance = Vector2.Subtract(location, boid.Position);
                    if (Vector2.Length(distance) < cohesionRange && this.boidId != boid.ID)
                    {
                        j++;
                        averagePosition = Vector2.Add(averagePosition, boid.Position);
                    }
                }

                if (j == 0)
                {
                    return new Vector2(0);
                }
                else
                {
                    averagePosition = averagePosition / j;
                    return new BoidActionSeek().DoAction(averagePosition, location, velocity, maxSpeed);
                }
        }
    }
}
