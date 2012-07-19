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
    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

    using SilverlightBoids.Boid;
    using SilverlightBoids.Logic;
    using SilverlightBoids.Logic.Styles;

    public partial class MainPage : UserControl
    {
        private  World _world;
        private  GameTimer _timer;
        private readonly FleeEllipse _fleeEllipse = new FleeEllipse();

        private bool once = false;

        private Point _mousePosition = new Point(0, 0);

        public MainPage(Option option)
        {
            this.InitializeComponent();

            MainCanvas.LayoutUpdated += (sender, args) =>
                {
                    if (!once)
                    {
                        WCFLogger.Info("Application started {0}", DateTime.Now.ToShortDateString());

                        this.MainCanvas.Children.Add(this._fleeEllipse);
                        this._world = new World(MainCanvas);

                        menuControl.World = this._world;

                        this._timer = new GameTimer(this.TimerCallback);

                        MainCanvas.MouseMove += this.MainPage_MouseMove;
                        once = true;

                        var scenario = new SavedScenario();
                        scenario.BoidsNumber = 100;

                        switch (option)
                        {
                            case Option.Custom:
                                break;
                            case Option.Wander:
                                scenario.WorldStatus = WorldStatus.GlobalWander;
                                break;
                            case Option.FCAS:
                                scenario.WorldStatus = WorldStatus.GlobalFCAS;
                                break;
                            case Option.Separater:
                                scenario.WorldStatus = WorldStatus.GlobalSeparate;
                                break;
                            case Option.Cohesion:
                                scenario.WorldStatus = WorldStatus.GlobalCohesion;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("option");
                        }

                        ApplyScenario(scenario);
                    }
                    else
                    {
                        _world.WorldHeight = MainCanvas.ActualHeight;
                        _world.WorldWidth = MainCanvas.ActualWidth;
                    }
                };
        }

        public void ApplyScenario(SavedScenario scenario)
        {
            _world.BoidList.Clear();

            _world.WorldStatus = scenario.WorldStatus;

            for (int i = 0; i < scenario.BoidsNumber; i++)
            {
                var newBoid = _world.CreateBoid();
                
                _world.Map.Children.Add(new BoidControl(newBoid));
            }

            _world.SetGlobalAction(WorldStatus.GlobalWander);
            this._world.Go(this._mousePosition);
            _world.SetGlobalAction(scenario.WorldStatus);
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
