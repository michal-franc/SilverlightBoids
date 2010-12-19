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

        public void AddBoidXY(Point p)
        {
            BoidControl Boid = new BoidControl(new Vector2(p),_boidList.Last().ID+1);
            BoidList.Add(Boid);
            _map.Children.Add(Boid);

        }

        public void AddBoidRandom()
        {
            int Id = 1;
            Random rand = new Random(DateTime.Now.Day + DateTime.Now.Millisecond);
            int x = rand.Next(1, 600);
            int y = rand.Next(1, 600);
            if (_boidList.Count > 0)
            {
                Id = _boidList.Last().ID + 1;
            }
            BoidControl Boid = new BoidControl(new Vector2(x,y ), Id);
            BoidList.Add(Boid);
            _map.Children.Add(Boid);
        }



        internal void Go(Point param)
        {
            foreach (BoidControl boid in _boidList)
            {
                boid.Go(GlobalAction, new Vector2(param));
            }
        }
    }
}
