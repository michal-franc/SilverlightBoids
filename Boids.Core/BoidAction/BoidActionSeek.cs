namespace Boids.Core.BoidAction
{
    public class BoidActionSeek : IBoidAction
    {
        public Vector2 DoAction(Vector2 dest, Vector2 location,Vector2 velocity,int maxSpeed)
        {
            //Little Check - if Dest == location the returning vector would have Nan Values after Substraction
            if (dest == location)
            {
                dest = Vector2.Zero;
            }

            Vector2 newVector = Vector2.Normalize(Vector2.Subtract(dest, location)) * maxSpeed;
            return Vector2.Subtract(newVector, velocity);
        }
    }
}
