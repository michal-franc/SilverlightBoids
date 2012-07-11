namespace Boids.Core.BoidAction
{
    public class BoidActionNoAction : IBoidAction
    {
        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            return new Vector2(0);
        }
    }
}
