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
using System.Collections.Generic;

namespace SilverlightBoids.Logic.BoidAction
{
    public class BoidActionAligment : IBoidAction
    {
        private BoidControl _leader;
        //private BoidActionSeek _seek;
        private IList<BoidControl> _boidList;

        //private int _aligmentRadius = 10;

        public BoidActionAligment(BoidControl packLeader, IList<BoidControl> boidList)
        {
            _leader = packLeader;
            _boidList = boidList;
            //_seek = new BoidActionSeek();
        }

        //#region IBoidAction Members

        //public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        //{
        //    //1. First Boid needs to get closer to the leader

        //    if (Vector2.Subtract(location, _leader.Position).Length() > _aligmentRadius)
        //    {
        //        return _seek.DoAction(_leader.Position, location, velocity, maxSpeed);
        //    }
        //    //2. Then it mimics leader movement
        //    else
        //        return _leader._steerForce;
        //}

        //#endregion

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            int j = 0;
            Vector2 averageDirection = new Vector2(0);
            Vector2 distance = new Vector2(0);
            for (int i = 0; i < _boidList.Count; i++)
            {
                distance = Vector2.Subtract(location, _boidList[i].Position);
                if (Vector2.Length(distance) < 100 && _boidList[i] != _leader)
                {
                    j++;
                    averageDirection = Vector2.Add(averageDirection, _boidList[i].Velocity);
                }
            }
            if (j == 0)
            {
                return new Vector2(0);
            }
            else
            {
                averageDirection = averageDirection / j;
                return Vector2.Subtract(averageDirection, Vector2.Add(velocity, new Vector2(0.0001f, 0.0001f)));
            }
        }
    }
}
