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

namespace SilverlightBoids
{
    public partial class MainPage : UserControl
    {
        private World _world;
        private DispatcherTimer _timer;
        private Point _mousePosition = new Point(0,0);
        private FleeEllipse _fleeEllipse = new FleeEllipse();

        public MainPage()
        {
            InitializeComponent();
            this.LayoutRoot.Children.Add(_fleeEllipse);
            _world = new World(LayoutRoot);
            menuControl1.World = _world;
            Logger.LogPage = txtBlockLog;



            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerCallback);
            _timer.Interval = TimeSpan.FromMilliseconds(2);
            _timer.Start();

            LayoutRoot.MouseMove += new MouseEventHandler(MainPage_MouseMove);

            for (int i = 0; i < 500; i++)
            {
                int id = _world.AddBoid();
            }
            _world.SetGlobalAction(WorldStatus.GlobalWander);
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
