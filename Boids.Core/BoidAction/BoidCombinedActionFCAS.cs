namespace Boids.Core.BoidAction
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Boids from colonies form groups in intelligent manner and avoid contact with randomly generated boids.
    /// </summary>
    public class BoidCombinedActionFCAS : IBoidAction
    {
        private BoidActionFlee _fleeAction;
        private BoidActionCohesion _cohesionAction;
        private BoidActionAligment _aligmentAction;
        private BoidActionSeparate _separateAction;
        private IList<Boid> _boidList;
        private IList<Boid> _randomPredatorBoidsList;

        public BoidCombinedActionFCAS(Boid boid, IList<Boid> boidList, IList<Boid> predatorBoidsList, int cohesionRadius)
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
