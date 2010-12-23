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

namespace SilverlightBoids.Logic
{
    public class BoidGroupActionCohesion : BoidGroupAction
    {

        private int cohesionRange=50;


        public BoidGroupActionCohesion(IList<BoidControl> group,int Id) : base(group,Id)
        {

        }

        #region IBoidAction Members

        public override Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
                int j = 0;
                Vector2 averagePosition = new Vector2(0);
                Vector2 distance = new Vector2(0);
                foreach (BoidControl boid in this.BoidGroup)
                {
                    distance = Vector2.Subtract(location, boid.Position);
                    if (Vector2.Length(distance) < cohesionRange && this.boidId != boid.ID)
                    {
                        j++;
                        averagePosition = Vector2.Add(averagePosition, boid.Position);
                        //averagePosition = Vector2.Multiply(averagePosition, 10);
                        //averagePosition = Vector2.Add(averagePosition,
                                //Vector2.Normalize(distance) / Vector2.Length(distance);
                    }
                }

                if (j == 0)
                {
                    return new Vector2(0);
                }
                else
                {
                    averagePosition = averagePosition / j;
                    return new BoidActionSeek().DoAction(averagePosition, location, velocity, maxSpeed);
                }
        }

        #endregion
    }
}
