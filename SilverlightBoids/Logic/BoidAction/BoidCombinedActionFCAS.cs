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
    /// <summary>
    /// Boids from colonies form groups in intelligent manner and avoid contact with randomly generated boids.
    /// (Works only with ONE random boid at the moment!!!)
    /// </summary>
    public class BoidCombinedActionFCAS : IBoidAction
    {
        private BoidActionFlee _fleeAction;
        private BoidActionCohesion _cohesionAction;
        private BoidActionAligment _aligmentAction;
        private BoidActionSeparate _separateAction;
        private IList<BoidControl> _boidList;
        private IList<BoidControl> _randomPredatorBoidsList;

        public BoidCombinedActionFCAS(BoidControl boid, IList<BoidControl> boidList, IList<BoidControl> predatorBoidsList, int cohesionRadius)
        {
            _boidList = boidList;
            _randomPredatorBoidsList = predatorBoidsList;
            _fleeAction = new BoidActionFlee();
            _cohesionAction = new BoidActionCohesion(boid, boidList, cohesionRadius);
            _aligmentAction = new BoidActionAligment(boid, boidList);
            _separateAction = new BoidActionSeparate(boid, boidList);
        }

        public Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            return
                Vector2.Add(
                    Vector2.Add(
                        Vector2.Add(
                            Vector2.Multiply(_fleeAction.DoAction(_randomPredatorBoidsList.First().Position, location, velocity, maxSpeed), .4f),
                            Vector2.Multiply(_cohesionAction.DoAction(dest, location, velocity, maxSpeed), .2f)),
                        Vector2.Multiply(_aligmentAction.DoAction(dest, location, velocity, maxSpeed), .5f)),
                    Vector2.Multiply(_separateAction.DoAction(dest, location, velocity, maxSpeed), .3f));
        }
    }
}
