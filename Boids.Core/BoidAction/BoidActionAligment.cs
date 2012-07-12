namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;

    public class BoidActionAligment : IBoidAction
    {
        private Boid leader;
        private IList<Boid> boidList;

        public BoidActionAligment(Boid packLeader, IList<Boid> boidList)
        {
            this.leader = packLeader;
            this.boidList = boidList;
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            int j = 0;
            Vector2 averageDirection = new Vector2(0);
            Vector2 distance = new Vector2(0);
            for (int i = 0; i < this.boidList.Count; i++)
            {
                distance = Vector2.Subtract(location, this.boidList[i].Position);
                if (Vector2.Length(distance) < 100 && this.boidList[i] != this.leader)
                {
                    j++;
                    averageDirection = Vector2.Add(averageDirection, this.boidList[i].Velocity);
                }
            }
            if (j == 0)
            {
                return new Vector2(0);
            }
            else
            {
                averageDirection = averageDirection / j;
                return Vector2.Subtract(averageDirection, Vector2.Add(velocity, new Vector2(0.0001f, 0.0001f)));
            }
        }
    }
}
