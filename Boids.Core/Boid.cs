namespace Boids.Core
{
    using System;

    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

    public class Boid
    {
        private int mass = (new Random()).Next(20, 80);

        private int maxForce = 20;

        private int maxSpeed = 10;

        public Boid(Vector2 position, int id)
        {
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.SteerForce = Vector2.Zero;

            this.Position = position;
            this.ID = id;
            this.Action = new BoidActionWander();
        }

        public Boid(int id)
        {
            this.Velocity = Vector2.Zero;
            this.Acceleration = Vector2.Zero;
            this.SteerForce = Vector2.Zero;

            this.ID = id;
            this.Action = new BoidActionWander();
        }

        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public Vector2 Acceleration { get; set; }

        public Vector2 SteerForce { get; set; }

        public int ID { get; private set; }

        public IBoidAction Action { get; set; }

        public int MaxSpeed 
        { 
            get
            {
                return this.maxSpeed;
            } 

            set
            {
                this.maxSpeed = value;
            }
        }

        public void Go(Vector2 dest, World world)
        {
            if (Action != null)
            {
                SteerForce = Action.DoAction(dest, Position, Velocity, MaxSpeed);
                SteerForce = Vector2.Truncate(SteerForce, this.maxForce);
                Acceleration = SteerForce / this.mass;
                Velocity = Vector2.Truncate(Velocity + Acceleration, this.maxSpeed);

                Position = CheckBoundaries(Vector2.Add(Velocity, Position), (int)world.WorldWidth, (int)world.WorldHeight);
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