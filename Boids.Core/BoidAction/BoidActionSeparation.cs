namespace Boids.Core.BoidAction
{
    using Boids.Core.WorldLogic;

    public class BoidActionSeparation : IBoidAction
    {
        private World _world;
        private int _separationRadius = 3;
        private int _id;

        private BoidActionFlee _flee;
        private BoidActionWander _wander;

        public BoidActionSeparation(World world,int id)
        {
            _world = world;
            _id = id;
            _flee = new BoidActionFlee();
            _wander = new BoidActionWander();
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            foreach (var boid in _world.BoidList)
            {
                if (boid.ID != _id)
                {
                    if (Vector2.Subtract(location, boid.Position).Length() < _separationRadius)
                    {
                        return _flee.DoAction(boid.Position, location, velocity, maxSpeed);
                    }
                }
            }
            return _wander.DoAction(dest, location, velocity, maxSpeed);
        }
    }
}
