using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Boids.Core.WorldLogic;

namespace Boids.Core
{
    public class BoidColony
    {
        private int _food = 100;

        public int Food
        {
            get
            {
                return _food;
            }
            set
            {
                _food = value;
            }
        }

        public IList<Boid> Boids { get; set; }
        public int BoidsCountLimit { get;  set; }
        public bool IsBoidsCountLimited { get;  set; }


        public BoidColony()
        {
            this.IsBoidsCountLimited = false;
            this.Boids = new List<Boid>();
        }
    }
}
