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

namespace SilverlightBoids.Logic.BoidAction
{
    public class BoidActionAligment : IBoidAction
    {
        private BoidControl _leader;
        private BoidActionSeek _seek;

        private int _aligmentRadius = 10;

        public BoidActionAligment(BoidControl packLeader)
        {
            _leader = packLeader;
            _seek = new BoidActionSeek();
        }

        #region IBoidAction Members

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            //1. First Boid needs to get closer to the leader

            if (Vector2.Subtract(location, _leader.Position).Length() > _aligmentRadius)
            {
                return _seek.DoAction(_leader.Position, location, velocity, maxSpeed);
            }
            //2. Then it mimics leader movement
            else
                return _leader._steerForce;
        }

        #endregion
    }
}
