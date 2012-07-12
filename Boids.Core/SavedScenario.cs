﻿namespace Boids.Core
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;

    using Boids.Core.BoidAction;
    using Boids.Core.WorldLogic;

    public class SavedScenario : RedisEntity
    {
        public int BoidsNumber { get; set; }

        public WorldStatus WorldStatus { get; set; }
    }
}
