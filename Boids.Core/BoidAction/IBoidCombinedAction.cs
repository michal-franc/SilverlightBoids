namespace Boids.Core.BoidAction
{
    public interface IBoidCombinedAction : IBoidAction
    {
        Vector2 CombineActions(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed, params IBoidAction[] actions);
    }
}
