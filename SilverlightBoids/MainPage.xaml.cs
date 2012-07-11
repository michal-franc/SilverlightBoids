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
    using System.Windows.Threading;

    using Boids.Core;
    using Boids.Core.WorldLogic;

    using NLog;

    using SilverlightBoids.Boid;
    using SilverlightBoids.Logic;
    using SilverlightBoids.Logic.Styles;

    public partial class MainPage : UserControl
    {
        public Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly World _world;
        private readonly GameTimer _timer;
        private readonly FleeEllipse _fleeEllipse = new FleeEllipse();

        private Point _mousePosition = new Point(0, 0);

        public MainPage()
        {
            var Logger = new LoggingService.LoggingServiceClient();
            Logger.LogMessageAsync("Silverlight application started.");

            this.InitializeComponent();

            this.MainCanvas.Children.Add(this._fleeEllipse);

            this._world = new World(MainCanvas);

            menuControl.World = this._world;

            this._timer = new GameTimer(this.TimerCallback);

            MainCanvas.MouseMove += this.MainPage_MouseMove;       
        }

        public void TimerCallback(object sender, EventArgs e)
        {
            this._world.Go(this._mousePosition);

            foreach (var boidControl in this._world.Map.Children.OfType<BoidControl>())
            {
                boidControl.Redraw();
            }

            this.CheckFleeEllipse();
        }

        private void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            var canvas = sender as Canvas;
            this._mousePosition = e.GetPosition(canvas);
        }

        private void CheckFleeEllipse()
        {
            if (this._world.WorldStatus != WorldStatus.GlobalFlee)
            {
                this._fleeEllipse.Visibility = Visibility.Collapsed;
            }
            else
            {
                this._fleeEllipse.Visibility = Visibility.Visible;
                this._fleeEllipse.Position = this._mousePosition;
            }
        }
    }
}
