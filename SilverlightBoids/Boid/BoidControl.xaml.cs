namespace SilverlightBoids.Boid
{
    using System;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Media;

    using Boids.Core;
    using Boids.Core.WorldLogic;

    public partial class BoidControl : UserControl
    {

        public BoidControl(Boid boid)
            : this(boid,Colors.Yellow)
        {
        }

        public BoidControl(Boid boid, Color boidColor)
        {
            this.Boid = boid;
            this.InitializeComponent();
            boidEllipse.Fill = new SolidColorBrush(boidColor);
        }

        public Vector2 Position
        {
            get
            {
                return Boid.Position;
            }

            set
            {
                Boid.Position = value;

            }
        }

        public Boid Boid { get; set; }

        public void Redraw()
        {
            if (!this.Position.IsNan)
            {
                this.SetValue(Canvas.LeftProperty, (double)Boid.Position.X);
                this.SetValue(Canvas.TopProperty, (double)Boid.Position.Y);
            }
        }
    }
}
