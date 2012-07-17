namespace SilverlightBoids
{
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
    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

    using SilverlightBoids.Boid;
    using SilverlightBoids.Logic;

    public partial class MenuControl
    {
        private IList<Point> _globalPath;

        public World World { get; set; }

        public MenuControl()
        {
            InitializeComponent();
        }

        private void btnAddBoidRandom_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxAddBoidNumber.Text))
            {
                var howMany = 0;
                if (int.TryParse(txtBoxAddBoidNumber.Text, out howMany))
                {
                    for (int i = 0; i < howMany; i++)
                    {
                        var newBoid = World.CreateBoid();
                        newBoid.Action = new BoidActionWander();
                        World.Map.Children.Add(new BoidControl(newBoid));
                    }
                }
            }
        }

        void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as UIElement;
            var newBoid = World.CreateBoid(e.GetPosition(element));
            World.Map.Children.Add(new BoidControl(newBoid));

        }

        private void btnAddBoid_Click(object sender, RoutedEventArgs e)
        {
            if (World.WorldStatus != WorldStatus.AddBoid)
            {
                World.Map.MouseLeftButtonDown += this.grid_MouseLeftButtonDown;
                World.WorldStatus = WorldStatus.AddBoid;
            }
            else
            {
                World.Map.MouseLeftButtonDown -= this.grid_MouseLeftButtonDown;
                World.WorldStatus = WorldStatus.None;
            }
        }

        private void btnFlee_Click(object sender, RoutedEventArgs e)
        {
            World.SetGlobalAction(WorldStatus.GlobalFlee);
            World.WorldStatus = WorldStatus.GlobalFlee;
        }

        private void btnSeek_Click(object sender, RoutedEventArgs e)
        {
            World.SetGlobalAction(WorldStatus.GlobalSeek);
            World.WorldStatus = WorldStatus.GlobalSeek;
        }

        private void btnFollowPath_Click(object sender, RoutedEventArgs e)
        {
            if (World.WorldStatus != WorldStatus.GlobalFollowPath)
            {
                _globalPath = new List<Point>();
                World.Map.MouseLeftButtonDown +=this.grid1_MouseLeftButtonDown;
                World.WorldStatus = WorldStatus.GlobalFollowPath;
            }
            else
            {
                World.Map.MouseLeftButtonDown -= this.grid1_MouseLeftButtonDown;
                World.GlobalPath = _globalPath;
                World.SetGlobalAction(WorldStatus.GlobalFollowPath);
                World.WorldStatus = WorldStatus.None;
            }
        }


        void grid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(_globalPath.Count>0)
            {
                Line line = new Line
                    {
                        X2 = e.GetPosition(this.World.Map).X,
                        Y2 = e.GetPosition(this.World.Map).Y,
                        X1 = this._globalPath.Last().X,
                        Y1 = this._globalPath.Last().Y,
                        StrokeThickness = 1,
                        Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255))
                    };

                World.Map.Children.Add(line);
                   
            }
            _globalPath.Add(e.GetPosition(World.Map));
        }

        private void btnSeparate_Click(object sender, RoutedEventArgs e)
        {
            World.WorldStatus = WorldStatus.GlobalSeparate;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnCohesion_Click(object sender, RoutedEventArgs e)
        {
            World.WorldStatus = WorldStatus.GlobalCohesion;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnFCAS_Click(object sender, RoutedEventArgs e)
        {
            World.WorldStatus = WorldStatus.GlobalFCAS;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnSaveScenario_Click(object sender, RoutedEventArgs e)
        {
            var savedScenario = new SavedScenario();
            savedScenario.BoidsNumber = World.BoidList.Count;
            savedScenario.WorldStatus = World.WorldStatus;

            var client = new DalService.RedisDalServiceClient();
            client.SaveScenarioAsync(savedScenario);
        }

        private void btnLoadScenario_Click(object sender, RoutedEventArgs e)
        {
            var client = new DalService.RedisDalServiceClient();
            client.LoadScenarioAsync();
            client.LoadScenarioCompleted += (o, args) => this.ApplyScenario(args.Result);
        }


        public void ApplyScenario(SavedScenario scenario)
        {
            World.BoidList.Clear();

            World.WorldStatus = scenario.WorldStatus;

            for (int i = 0; i < scenario.BoidsNumber; i++)
            {
                var newBoid = World.CreateBoid();
                newBoid.Action = new BoidActionWander();
                World.Map.Children.Add(new BoidControl(newBoid));
            }
        }
    }
}
