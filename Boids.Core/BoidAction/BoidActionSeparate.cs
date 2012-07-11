namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;

    public class BoidActionSeparate : IBoidAction
    {
        private Boid _boid;
        private IList<Boid> _boidList;

        public BoidActionSeparate(Boid boid, IList<Boid> boidList)
        {
            _boidList = new List<Boid>();
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
