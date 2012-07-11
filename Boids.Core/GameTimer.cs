using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SilverlightBoids.Logic
{
    public class GameTimer
    {
        private readonly DispatcherTimer _timer;

        public GameTimer(EventHandler timerEvent)
        {
            _timer = new DispatcherTimer();
            _timer.Tick += timerEvent;
            _timer.Interval = TimeSpan.FromMilliseconds(1);
            _timer.Start();
        }
    }
}
