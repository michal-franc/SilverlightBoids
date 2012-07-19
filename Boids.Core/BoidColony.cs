namespace Boids.Core
{
    using System.Collections.Generic;

    public class BoidColony
    {
        private int food = SimulationSettings.DefaultColonyFood;

        public BoidColony()
        {
            this.IsBoidsCountLimited = false;
            this.Boids = new List<Boid>();
        }

        public IList<Boid> Boids { get; set; }

        public int BoidsCountLimit { get; set; }

        public bool IsBoidsCountLimited { get; set; }


        public int Food
        {
            get
            {
                return this.food;
            }

            set
            {
                this.food = value;
            }
        }
    }
}
