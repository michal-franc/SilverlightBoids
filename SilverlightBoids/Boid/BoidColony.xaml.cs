﻿using System;
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
using SilverlightBoids.Logic;
using System.Threading;
using System.Windows.Threading;


namespace SilverlightBoids.Boid
{
    public partial class BoidColony : UserControl
    {
        private Vector2 _position;

        private WorldLogic.World World { get; set; }

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

        public IList<BoidControl> Boids { get; set; }

        public Color ColonyColor { get; set; }

        public BoidColony(Color color,Vector2 position, WorldLogic.World world)
        {
            InitializeComponent();

            Boids = new List<BoidControl>();
            Position = position;
            ColonyColor = color;
            Rect.Fill = new SolidColorBrush(color);
            World = world;
        }

        private int GetNewId()
        {
            int Id = 1;
            if (Boids.Count > 0)
            {
                Id = Boids.Last().ID + 1;
            }

            return Id;
        } 

        public void ProduceBoids(object state)
        {
            TimeSpan interval = (TimeSpan)state;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = interval;
            timer.Tick += new EventHandler(GiveBirthToNiceBoid);
            timer.Start();
        }

        private void GiveBirthToNiceBoid(object sender, EventArgs e)
        {
            BoidControl boid = new BoidControl(Position, 2);
            Boids.Add(boid);
            World.Map.Children.Add(boid);
            //TextBlock tb = World.Map.FindName("debugTextBlock") as TextBlock;
            //tb.Text = World.Map.Children.Count.ToString();
        }

        public void ProduceBoids(TimeSpan interval, int numberOfBoids)
        {

        }
    }
}