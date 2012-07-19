namespace Boids.Core
{
    using System;
    using System.Windows.Threading;

    public class GameTimer
    {
        private readonly DispatcherTimer _timer;

        public GameTimer(EventHandler timerEvent)
        {
            this._timer = new DispatcherTimer();
            this._timer.Tick += timerEvent;
            this._timer.Interval = TimeSpan.FromMilliseconds(1);
            this._timer.Start();
        }
    }
}
