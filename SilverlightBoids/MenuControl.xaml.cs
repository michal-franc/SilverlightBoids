using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightBoids.Logic;

namespace SilverlightBoids
{
    public partial class MenuControl : UserControl
    {
        public World World { get; set; }
        public MenuControl()
        {
            InitializeComponent();
        }

        private void btnAddBoidRandom_Click(object sender, RoutedEventArgs e)
        {
            World.AddBoidRandom();
        }

        private void btnAddBoid_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Add Boid";
            //this.Parent.
        }

        private void btnFlee_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Flee";
            World.GlobalAction = new BoidActionFlee();
        }

        private void btnSeek_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Seek";
            World.GlobalAction = new BoidActionSeek();
        }
    }
}
