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
using SilverlightBoids.Logic;
using SilverlightBoids.Logic.Styles;
using SilverlightBoids.WorldLogic;

namespace SilverlightBoids
{
    public partial class MainPage : UserControl
    {
        private WorldLogic.World _world;
        private GameTimer _timer;
        private Point _mousePosition = new Point(0,0);
        private FleeEllipse _fleeEllipse = new FleeEllipse();

        public MainPage()
        {
            InitializeComponent();
            this.MainCanvas.Children.Add(_fleeEllipse);
            _world = new WorldLogic.World(MainCanvas);
            menuControl1.World = _world;
            Logger.LogDestination = txtBlockLog;

            _timer = new GameTimer(new EventHandler(TimerCallback));

            MainCanvas.MouseMove += new MouseEventHandler(MainPage_MouseMove);



            //Parameters of starting simulation
            for (int i = 0; i < 500; i++)
            {
                int id = _world.AddBoid();
            }

            for (int i = 0; i < 100; i++)
            {
                _world.AddWorldObject(new WorldObjectFood(2));
            }

                _world.SetGlobalAction(WorldStatus.LookForFood);
        }

        void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            Canvas canvas = sender as Canvas;
            _mousePosition = e.GetPosition(canvas);
        }

        public void TimerCallback(object sender, EventArgs e)
        {
            _world.Go(_mousePosition);

            CheckFleeEllipse();
        }

        private void CheckFleeEllipse()
        {
            if (_world.WorldStatus != WorldStatus.GlobalFlee)
                _fleeEllipse.Visibility = System.Windows.Visibility.Collapsed;
            else
            {
                _fleeEllipse.Visibility = System.Windows.Visibility.Visible;
                _fleeEllipse.Position = _mousePosition;
            }
        }
    }
}
