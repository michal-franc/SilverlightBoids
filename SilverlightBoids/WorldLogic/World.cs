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
using SilverlightBoids.Logic;
using System.Linq;
using SilverlightBoids.Boid;
using SilverlightBoids.Logic.BoidAction;
using System.Threading;


namespace SilverlightBoids.WorldLogic
{

    public enum WorldStatus
    {
        None,
        GlobalSeek,
        GlobalFlee,
        GlobalFollowPath,
        GlobalWander,
        GlobalCohesion,
        AddBoid,
        LookForFood,
        AddingColony
    }

    public class World
    {
        private int _colonyPositionRadius = 200;

        Random rand = new Random(DateTime.Now.Day + DateTime.Now.Millisecond);
        #region Fields
        public Panel Map { get; set; }
        private IList<BoidColony> _boidColonies = new List<BoidColony>();
        private IList<BoidControl> _boidList = new List<BoidControl>();
        private IList<WorldObjectContainer> _worldObjectsList = new List<WorldObjectContainer>();

        public WorldStatus WorldStatus { get; set; }

        public IList<BoidControl> BoidList
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
            WorldHeight = 800;
            WorldWidth =  500;
        }
        #endregion

        #region Public Methods
        public int AddBoid(Point p)
        {
            int id = GetNewId();
            BoidControl boid = new BoidControl(new Vector2(p), GetNewId());
            AddBoid(boid);
            return id;

        }

        public int AddBoid()
        {
            int id = GetNewId();
            BoidControl boid = new BoidControl(GetRandomVector(), GetNewId());
            AddBoid(boid);
            return id;
        }


        public  void SetGlobalAction(WorldStatus status)
        {
            foreach(BoidControl boid in this._boidList)
            {
                SetBoidAction(boid, status);
            }

            foreach (var colony in _boidColonies)
            {
                foreach (var boid in colony.Boids)
                {
                    SetBoidAction(boid, status);
                }
            }
        }

        public void SetBoidAction(BoidControl boid, WorldStatus status)
        {
            if (status == WorldStatus.GlobalFollowPath)
                boid.Action = new BoidActionFollowPath(GlobalPath);
            else if (status == WorldStatus.GlobalFlee)
                boid.Action = new BoidActionFlee();
            else if (status == WorldStatus.GlobalSeek)
                boid.Action = new BoidActionSeek();
            else if (status == WorldStatus.GlobalWander)
                boid.Action = new BoidActionWander();
            else if (status == WorldLogic.WorldStatus.LookForFood)
                boid.Action = new BoidActionLookFor(new WorldObjectFood(1), this);
            else if (status == WorldLogic.WorldStatus.GlobalCohesion)
                boid.Action = new BoidGroupActionCohesion(_boidList, boid.ID);
        }

        public void AddColony()
        {
            //Place Colony Randomaly in some radius from another colony
            Vector2 position = GetRandomVector();
            foreach (BoidColony colony in this._boidColonies)
            {
                if (Vector2.Subtract(colony.Position, position).Length() < _colonyPositionRadius)
                {
                    position = GetRandomVector();
                }
            }

            //Vector2 position = new Vector2(x,y);

            BoidColony newColony = new BoidColony(SilverlightBoids.Logic.Styles.Colors.GetColor() , position, this);
            this.Map.Children.Add(newColony);
        }

        public void AddColony(Point placeOfColony, Color color)
        {
            BoidColony newColony = new BoidColony(color, new Vector2(placeOfColony), this);
            _boidColonies.Add(newColony);
            Map.Children.Add(newColony);
            //ThreadPool.QueueUserWorkItem(newColony.ProduceBoids, TimeSpan.FromSeconds(1));
            newColony.ProduceBoids(TimeSpan.FromSeconds(1));
        }

        public void Go(Point param)
        {
            foreach (BoidControl boid in _boidList)
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

        public void AddWorldObject(WorldObject worldObject)
        {
            WorldObjectContainer container = new WorldObjectContainer(worldObject);
            container.Position = GetRandomVector();
            Map.Children.Add(container);
            _worldObjectsList.Add(container);
        }

        #endregion

        #region Private Methods
        private void AddBoid(BoidControl boid)
        {
            BoidList.Add(boid);
            Map.Children.Add(boid);
        }


        private Vector2 GetRandomVector()
        {

            double x = rand.NextDouble() * WorldWidth;
            double y = rand.NextDouble() * WorldHeight;

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

        internal Vector2 LookFor(WorldObject _objectToLookFor, Vector2 location,int radius)
        {
            foreach (WorldObjectContainer obj in this._worldObjectsList)
            {
                if (obj.ContainedObject.GetType() ==  _objectToLookFor.GetType())
                {
                    if (obj.Position.X > location.X - radius && obj.Position.X < location.X + radius)
                    {
                        if (obj.Position.Y > location.Y - radius && obj.Position.Y < location.Y + radius)
                        {
                            return obj.Position;
                        }
                    }
                }   
            }

            return Vector2.Zero;
        }
    }
}
