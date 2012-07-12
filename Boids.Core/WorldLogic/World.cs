using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Boids.Core.BoidAction;

namespace Boids.Core.WorldLogic
{
    using System.Linq;

    public enum WorldStatus
    {
        None,
        GlobalSeek,
        GlobalFlee,
        GlobalFollowPath,
        GlobalWander,
        GlobalCohesion,
        GlobalArrive,
        GlobalSeparate,
        GlobalAligment,
        GlobalFCAS,
        AddBoid,
        LookForFood,
        AddingColony,
        AddingRockObject
    }

    public class World
    {
        private int _colonyPositionRadius = 200;

        #region Fields
        public Panel Map { get; set; }
        private IList<BoidColony> _boidColonies = new List<BoidColony>();
        private IList<Boid> _boidList = new List<Boid>();

        public WorldStatus WorldStatus { get; set; }

        public IList<Boid> BoidList
        {
            get
            {
                return _boidList;
            }
        }

        public double WorldWidth { get; set; }
        public double WorldHeight { get; set; }

        public IList<Point> GlobalPath { get; set; }
        #endregion

        #region CTOR

        public World(Panel map)
        {
            WorldStatus = WorldStatus.None;
            Map = map;
            WorldHeight = map.ActualHeight;
            WorldWidth = map.ActualWidth;
        }
        #endregion

        #region Public Methods
        public Boid CreateBoid()
        {
            int id = GetNewId();
            var boid = new Boid(GetRandomVector(), id);
            BoidList.Add(boid);
            return boid;
        }

        public Boid CreateBoid(Point p)
        {
            int id = GetNewId();
            var boid = new Boid(new Vector2(p.X,p.Y), id);
            BoidList.Add(boid);
            return boid;
        }


        public void SetGlobalAction(WorldStatus status)
        {
            foreach (Boid boid in this._boidList)
            {
                SetBoidAction(boid, _boidList, status);
            }

            foreach (var colony in _boidColonies)
            {
                foreach (var boid in colony.Boids)
                {
                    SetBoidAction(boid, colony.Boids, status);
                }
            }
        }

        public void SetBoidAction(Boid boid, IList<Boid> boidList, WorldStatus status)
        {
            if (status == WorldStatus.GlobalFollowPath)
                boid.Action = new BoidActionFollowPath(GlobalPath);
            else if (status == WorldStatus.GlobalFlee)
                boid.Action = new BoidActionFlee();
            else if (status == WorldStatus.GlobalSeek)
                boid.Action = new BoidActionSeek();
            else if (status == WorldStatus.GlobalWander || status == WorldStatus.GlobalFCAS && boid.ID == 1)
            {
                boid.Action = new BoidActionWander();
                boid.MaxSpeed = 2;
            }
            else if (status == WorldStatus.LookForFood)
                boid.Action = new BoidActionLookFor(new WorldObjectFood(1), this);
            else if (status == WorldStatus.GlobalCohesion)
                boid.Action = new BoidActionCohesion(boid, boidList, 100);
            else if (status == WorldStatus.GlobalArrive)
                boid.Action = new BoidActionArrive();
            else if (status == WorldStatus.GlobalSeparate)
                boid.Action = new BoidActionSeparate(boid, boidList);
            else if (status == WorldStatus.GlobalAligment)
                boid.Action = new BoidActionAligment(boid, boidList);
            else if (status == WorldStatus.GlobalFCAS)
                boid.Action = new BoidCombinedActionFCAS(boid, boidList, _boidList, 100);
        }

        public void Go(Point param)
        {
            foreach (Boid boid in _boidList)
            {
                boid.Go(new Vector2(param),this);
            }

            foreach (var colony in _boidColonies)
            {
                foreach (var boid in colony.Boids)
                {
                    boid.Go(new Vector2(param), this);
                }
            }
        }
        #endregion

        #region Private Methods
        private Vector2 GetRandomVector()
        {
            Random randomGenerator = new Random(DateTime.Now.Day + DateTime.Now.Millisecond);
            double x = randomGenerator.NextDouble() * WorldWidth;
            double y = randomGenerator.NextDouble() * WorldHeight;
            return new Vector2(x, y);
        }


        private int GetNewId()
        {
            int Id = 1;
            if (_boidList.Count > 0)
            {
                Id = _boidList.Last().ID + 1;
            }

            return Id;
        } 
        #endregion

        //todo: this has to be rewritten with new code
        //internal Vector2 LookFor(IWorldObject _objectToLookFor, Vector2 location,int radius)
        //{
        //    foreach (SilverlightBoids.WorldObjectContainer obj in this._worldObjectsList)
        //    {
        //        if (obj.ContainedObject.GetType() ==  _objectToLookFor.GetType())
        //        {
        //            if (obj.Position.X > location.X - radius && obj.Position.X < location.X + radius)
        //            {
        //                if (obj.Position.Y > location.Y - radius && obj.Position.Y < location.Y + radius)
        //                {
        //                    return obj.Position;
        //                }
        //            }
        //        }   
        //    }

        //    return Vector2.Zero;
        //}
    }
}
