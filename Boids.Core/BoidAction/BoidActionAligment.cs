namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;

    public class BoidActionAligment : IBoidAction
    {
        private Boid _leader;
        //private BoidActionSeek _seek;
        private IList<Boid> _boidList;

        //private int _aligmentRadius = 10;

        public BoidActionAligment(Boid packLeader, IList<Boid> boidList)
        {
            _leader = packLeader;
            _boidList = boidList;
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            int j = 0;
            Vector2 averageDirection = new Vector2(0);
            Vector2 distance = new Vector2(0);
            for (int i = 0; i < _boidList.Count; i++)
            {
                distance = Vector2.Subtract(location, _boidList[i].Position);
                if (Vector2.Length(distance) < 100 && _boidList[i] != _leader)
                {
                    j++;
                    averageDirection = Vector2.Add(averageDirection, _boidList[i].Velocity);
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
