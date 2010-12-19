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
using System.Windows.Threading;
using SilverlightBoids.Logic;

namespace SilverlightBoids
{
    public partial class MainPage : UserControl
    {
        private World _world;
        private DispatcherTimer _timer;
        private Point mousePosition = new Point(0,0);

        public MainPage()
        {
            InitializeComponent();

            _world = new World(LayoutRoot);
            menuControl1.World = _world;


            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(TimerCallback);
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Start();

            this.MouseMove += new MouseEventHandler(MainPage_MouseMove);
        }

        void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = e.GetPosition(this);
        }

        public void TimerCallback(object sender, EventArgs e)
        {
            _world.Go(mousePosition);
        }
    }
}
