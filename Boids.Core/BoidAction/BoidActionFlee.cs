namespace Boids.Core.BoidAction
{
    public class BoidActionFlee : IBoidAction
    {
        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            if (Vector2.Length(Vector2.Subtract(dest, location)) > SimulationSettings.FleeRadius)
            {
                return new Vector2(0);
            }
            else
            {
                Vector2 newVector = Vector2.Normalize(Vector2.Subtract(location, dest)) * maxSpeed;
                return Vector2.Subtract(newVector, velocity);
            }
        }
    }
}
