namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;

    public class BoidActionCohesion : IBoidAction
    {
        private Boid _leader;
        private IList<Boid> _boidList;
        private int _cohesionRadius;
        private BoidActionSeek _seekAction;

        public BoidActionCohesion(Boid leader, IList<Boid> boidList, int cohesionRadius)
        {
            _leader = leader;
            _boidList = boidList;
            _cohesionRadius = cohesionRadius;
            _seekAction = new BoidActionSeek();
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            int j = 0;
                Vector2 averagePosition = new Vector2(0);
                Vector2 distance = new Vector2(0);
                for (int i = 0; i < _boidList.Count; i++)
                {
                    distance = Vector2.Subtract(location, _boidList[i].Position);
                    if (Vector2.Length(distance) < _cohesionRadius && _boidList[i] != _leader)
                    {
                        j++;
                        averagePosition = Vector2.Add(averagePosition, _boidList[i].Position);
                    }
                }

                if (j == 0)
                {
                    return new Vector2(0,0);
                }
                else
                {
                    averagePosition = averagePosition / j;
                    return _seekAction.DoAction(averagePosition, location, velocity, maxSpeed);
                }
        }
    }
}
