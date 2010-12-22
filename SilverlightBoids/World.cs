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

namespace SilverlightBoids
{

    public enum WorldStatus
    {
        None,
        GlobalSeek,
        GlobalFlee,
        GlobalFollowPath,
        AddBoid

    }

    public class World
    {
        #region Fields
        private Panel _map;
        private IList<BoidControl> _boidList = new List<BoidControl>();

        public WorldStatus WorldStatus { get; set; }

        public IList<BoidControl> BoidList
        {
            get
            {
                return _boidList;
            }
        }



        public IList<Point> GlobalPath { get; set; }
        #endregion

        #region CTOR
        public World(Panel map)
        {
            WorldStatus = WorldStatus.None;
            _map = map;

        } 
        #endregion

        #region Public Methods
        public void AddBoid(Point p)
        {
            BoidControl boid = new BoidControl(new Vector2(p), GetNewId());
            AddBoid(boid);

        }

        public void AddBoid()
        {
            BoidControl boid = new BoidControl(GetRandomVector(), GetNewId());
            AddBoid(boid);
        }


        public  void SetGlobalAction(WorldStatus status)
        {
            foreach(BoidControl boid in this._boidList)
            {
                if(status == SilverlightBoids.WorldStatus.GlobalFollowPath)
                     boid.Action = new BoidActionFollowPath(GlobalPath);
                else if(status == SilverlightBoids.WorldStatus.GlobalFlee)
                    boid.Action = new BoidActionFlee();
                else if (status == SilverlightBoids.WorldStatus.GlobalSeek)
                    boid.Action = new BoidActionSeek();

            }
        }


        public void Go(Point param)
        {
            foreach (BoidControl boid in _boidList)
            {
                boid.Go(new Vector2(param));
            }
        } 
        #endregion

        #region Private Methods
        private void AddBoid(BoidControl boid)
        {
            BoidList.Add(boid);
            _map.Children.Add(boid);
        }

        private Vector2 GetRandomVector()
        {
            Random rand = new Random(DateTime.Now.Day + DateTime.Now.Millisecond);
            int x = rand.Next(1, 600);
            int y = rand.Next(1, 600);

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
