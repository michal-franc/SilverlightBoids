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
    public class BoidGroupAction : IBoidAction
    {
        public IList<BoidControl> BoidGroup { protected get; set; }
        protected int boidId = 0;


        public BoidGroupAction(IList<BoidControl> boidGroup,int Id)
        {
            this.BoidGroup = boidGroup;
            boidId = Id;
        }

        #region IBoidAction Members

        public virtual Vector2 DoAction(Vector2 dest, Vector2 location, Vector2 velocity, int maxSpeed)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
