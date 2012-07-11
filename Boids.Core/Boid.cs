namespace Boids.Core
{
    using System;

    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

    public class Boid
    {
        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        public Vector2 SteerForce { get; set; }

        public int ID { get; private set; }
        public int _mass = (new Random()).Next(20, 80);
        public int _maxForce = 20;
        public int _maxSpeed = 10;
        public IBoidAction Action { get; set; }

        public int MaxSpeed 
        { 
            get
            {
                return _maxSpeed;
            } 

            set
            {
                _maxSpeed = value;
            }
        }

        public Boid(Vector2 position,int id)
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            SteerForce = Vector2.Zero;

            Position = position;
            this.ID = id;
            this.Action = new BoidActionWander();
        }

        public Boid(int id)
        {
            Velocity = Vector2.Zero;
            Acceleration = Vector2.Zero;
            SteerForce = Vector2.Zero;

            this.ID = id;
            this.Action = new BoidActionWander();
        }

        public void Go(Vector2 dest, World world)
        {
            if (Action != null)
            {
                SteerForce = Action.DoAction(dest, Position, Velocity, MaxSpeed);
                SteerForce = Vector2.Truncate(SteerForce, _maxForce);
                Acceleration = SteerForce / _mass;
                Velocity = Vector2.Truncate(Velocity + Acceleration, _maxSpeed);

                Position = CheckBoundaries(Vector2.Add(Velocity, Position), (int)world.WorldHeight, (int)world.WorldWidth);
            }
        }

        public Vector2 CheckBoundaries(Vector2 newPosition, int maxX, int maxY)
        {
            if (newPosition.X > maxX)
                newPosition.X = 0;
            if (newPosition.Y > maxY)
                newPosition.Y = 0;
            if (newPosition.X < 0)
                newPosition.X = maxX;
            if (newPosition.Y < 0)
                newPosition.Y = maxY;

            return newPosition;
        }
    }
}