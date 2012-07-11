namespace Boids.Core.BoidAction
{
    public class BoidActionSimple : IBoidAction
    {
        public Vector2 DoAction(Vector2 dest, Vector2 location,Vector2 velocity,int maxSpeed)
        {
            return new Vector2(location.X + 1, location.Y + 1);
        }
    }
}
