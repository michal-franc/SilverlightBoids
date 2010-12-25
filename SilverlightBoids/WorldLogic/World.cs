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

namespace SilverlightBoids.WorldLogic
{

    public enum WorldStatus
    {
        None,
        GlobalSeek,
        GlobalFlee,
        GlobalFollowPath,
        GlobalWander,
        AddBoid,
    }

    public class World
    {
        #region Fields
        public Panel Map { get; set; }
        private IList<Colony> _boidColonies = new List<Colony>();
        private IList<BoidControl> _boidList = new List<BoidControl>();

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
                if(status == WorldStatus.GlobalFollowPath)
                     boid.Action = new BoidActionFollowPath(GlobalPath);
                else if(status == WorldStatus.GlobalFlee)
                    boid.Action = new BoidActionFlee();
                else if (status == WorldStatus.GlobalSeek)
                    boid.Action = new BoidActionSeek();
                else if (status == WorldStatus.GlobalWander)
                    boid.Action = new BoidActionWander(boid.ID);

            }
        }


        public void Go(Point param)
        {
            foreach (BoidControl boid in _boidList)
            {
                boid.Go(new Vector2(param),this);
            }
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            WorlfObjectContainer container = new WorlfObjectContainer(worldObject);
            container.Position = GetRandomVector();
            Map.Children.Add(container);
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
            Random rand = new Random(DateTime.Now.Day + DateTime.Now.Millisecond);
            int x = rand.Next(1, (int)WorldWidth);
            int y = rand.Next(1, (int)WorldHeight);

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


    }
}
