using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Boids.Core;
using SilverlightBoids.Logic;
using System.Threading;
using System.Windows.Threading;


namespace SilverlightBoids.Boid
{
    using Boids.Core.WorldLogic;

    public partial class BoidColonyControl : UserControl
    {
        public Color ColonyColor { get; set; }
        private World World { get; set; }

        private Vector2 _position;

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                if (value.X >= 0 && value.Y >= 0)
                {
                    this.SetValue(Canvas.LeftProperty, (double)value.X);
                    this.SetValue(Canvas.TopProperty, (double)value.Y);
                }
            }
        }

        private BoidColony BoidColony { get; set; }

        #region ctor

        public BoidColonyControl(Color color, Vector2 position, World world)
        {
            InitializeComponent();
            BoidColony = new BoidColony();
            Position = position;
            ColonyColor = color;
            Rect.Fill = new SolidColorBrush(color);
            World = world;
            GiveBirthToANiceBoid(this, new EventArgs());
        }

        #endregion

        private int CreateNextId()
        {
            if (BoidColony.Boids.Count <= 0)
                return 1;

            return BoidColony.Boids.Last().ID + 1;
        }

        public void ProduceBoids(TimeSpan interval)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = interval;
            timer.Tick += GiveBirthToANiceBoid;
            timer.Start();
        }

        public void ProduceBoids(TimeSpan interval, int boidsLimit)
        {
            BoidColony.IsBoidsCountLimited = true;
            BoidColony.BoidsCountLimit = boidsLimit;
            ProduceBoids(interval);
        }

        private void GiveBirthToANiceBoid(object sender, EventArgs e)
        {
            //BoidControl boid = new BoidControl(Position, CreateNextId(), ColonyColor);
            //BoidColony.Boids.Add(boid.Boid);
            //World.Map.Children.Add(boid);
            //World.SetBoidAction(boid.Boid, BoidColony.Boids, World.WorldStatus);
            //if (BoidColony.IsBoidsCountLimited && BoidColony.Boids.Count >= BoidColony.BoidsCountLimit)
            //    (sender as DispatcherTimer).Stop();
        }

    }
}
