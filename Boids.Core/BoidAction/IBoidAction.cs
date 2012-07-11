namespace Boids.Core.BoidAction
{
    public interface IBoidAction
    {
        Vector2 DoAction(Vector2 dest, Vector2 location,Vector2 velocity,int maxSpeed);
    }
}
