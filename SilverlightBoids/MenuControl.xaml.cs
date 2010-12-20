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
        private int status = 0;
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
            Grid grid = this.Parent as Grid;
            if (status == 0)
            {
                grid.MouseLeftButtonDown += new MouseButtonEventHandler(grid_MouseLeftButtonDown);
                status = 1;
            }
            else
            {
                grid.MouseLeftButtonDown -= new MouseButtonEventHandler(grid_MouseLeftButtonDown);
                status = 0;
            }
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

        private void btnFollowPath_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Follow Path";
            World.GlobalAction = new BoidActionFollowPath(new List<Point>() { new Point(10, 10), new Point(100, 100), new Point(100, 200) });
        }

        void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UIElement element = sender as UIElement;
            World.AddBoidXY(e.GetPosition(element));
        }
    }
}
