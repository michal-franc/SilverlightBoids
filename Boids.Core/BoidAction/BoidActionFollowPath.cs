using System.Collections.Generic;
using System.Windows;

namespace Boids.Core.BoidAction
{
    public class BoidActionFollowPath : IBoidAction
    {
        private IList<Point> _path;
        private IBoidAction _seek;
        private int _pathCounter = 0;

        public BoidActionFollowPath(IList<Point> path)
        {
            _path = path;
            _seek = new BoidActionSeek();
        }

        #region IBoidAction Members

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            if(Vector2.Subtract(location,new Vector2(_path[_pathCounter])).Length() <= 2)
            {
                _pathCounter++;
            }
            return _seek.DoAction(new Vector2(_path[_pathCounter]),location,velocity,maxSpeed);
        }

        #endregion
    }
}
