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

namespace SilverlightBoids
{
    public partial class MainPage : UserControl
    {
        private World _world;
        private DispatcherTimer _timer;
        private Point _mousePosition = new Point(0,0);
        private Ellipse _fleeEllipse = new Ellipse();

        public MainPage()
        {
            InitializeComponent();

            _world = new World(LayoutRoot);
            menuControl1.World = _world;

            _fleeEllipse.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 255));
            _fleeEllipse.Width = 50;
            _fleeEllipse.Height = 50;


            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerCallback);
            _timer.Interval = TimeSpan.FromMilliseconds(2);
            _timer.Start();

            this.MouseMove += new MouseEventHandler(MainPage_MouseMove);

            for (int i = 0; i < 200; i++)
            {
                _world.AddBoid();
            }
        }

        void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            _mousePosition = e.GetPosition(this);
        }

        public void TimerCallback(object sender, EventArgs e)
        {
            _world.Go(_mousePosition);

            DrawFleeEllipse();
        }

        private void DrawFleeEllipse()
        {
            if (_world.WorldStatus == WorldStatus.GlobalFlee)
            {
                _fleeEllipse.SetValue(Canvas.LeftProperty, (double)_mousePosition.X-25);
                _fleeEllipse.SetValue(Canvas.TopProperty, (double)_mousePosition.Y-25);

                if (!LayoutRoot.Children.Contains(_fleeEllipse))
                {
                    LayoutRoot.Children.Add(_fleeEllipse);
                }
            }
        }
    }
}
