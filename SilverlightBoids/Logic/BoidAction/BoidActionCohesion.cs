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
using System.Linq;

namespace SilverlightBoids.Logic.BoidAction
{
    public class BoidActionCohesion : IBoidAction
    {
//        public static Vector2 Cohesion(ref Vehicle[] allCars,Vehicle me,
//              Vector2 currentPosition, Vector2 velocity,
//              int max_speed, int cohesionRadius)
//{
//    int j = 0;
//    Vector2 averagePosition = new Vector2(0);
//    Vector2 distance = new Vector2(0);
//    for (int i = 0; i < allCars.Length; i++)
//    {
//        distance = Vector2.Subtract(currentPosition, allCars[i].CurrentPosition);
//        if (Vector2.Length(distance) < cohesionRadius && allCars[i] != me)
//        {
//            j++;
//            averagePosition = Vector2.Add(averagePosition, allCars[i].CurrentPosition);
//            //averagePosition = Vector2.Multiply(averagePosition, 10);
//            //averagePosition = Vector2.Add(averagePosition,
//                    Vector2.Normalize(distance) / Vector2.Length(distance));
//        }
//    }
//    if (j == 0)
//    {
//        return None();
//    }
//    else
//    {
//        averagePosition = averagePosition / j;
//        return Seek(ref averagePosition, ref currentPosition,
//                    ref velocity, max_speed);
//    }
//}

        private BoidControl _leader;
        private IList<BoidControl> _boidList;
        private int _cohesionRadius;
        private BoidActionSeek _seekAction;


        public BoidActionCohesion(BoidControl leader, IList<BoidControl> boidList, int cohesionRadius)
        {
            _leader = leader;
            _boidList = boidList;
            _cohesionRadius = cohesionRadius;
            _seekAction = new BoidActionSeek();
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            int j = 0;
                Vector2 averagePosition = new Vector2(0);
                Vector2 distance = new Vector2(0);
                for (int i = 0; i < _boidList.Count; i++)
                {
                    distance = Vector2.Subtract(location, _boidList[i].Position);
                    if (Vector2.Length(distance) < _cohesionRadius && _boidList[i] != _leader)
                    {
                        j++;
                        averagePosition = Vector2.Add(averagePosition, _boidList[i].Position);
                    }
                }
                //test();
                if (j == 0)
                {
                    return new Vector2(0,0);
                }
                else
                {
                    averagePosition = averagePosition / j;
                    return _seekAction.DoAction(averagePosition, location, velocity, maxSpeed);
                }
                
        }

        private void test()
        {
            var d = from b in _boidList where b.Position.IsNan == true select b;
            if (d.Count() > 0)
                throw new Exception("DUPAAAAAA!");
        }
    }
}
