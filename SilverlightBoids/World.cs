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
    public class World
    {
        private Panel _map;
        public IBoidAction GlobalAction { get; set; }
        private IList<BoidControl> _boidList = new List<BoidControl>();

        public  IList<BoidControl> BoidList 
        { 
            get
            {
                return _boidList;
            }
        }

        public World(Panel map)
        {
            _map = map;

        }

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


        public void Go(Point param)
        {
            foreach (BoidControl boid in _boidList)
            {
                boid.Go(GlobalAction, new Vector2(param));
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
