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
        private IList<Point> _globalPath;
        public World World { get; set; }
        public MenuControl()
        {
            InitializeComponent();
        }

        private void btnAddBoidRandom_Click(object sender, RoutedEventArgs e)
        {
            World.AddBoid();
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
            Grid grid = this.Parent as Grid;
            if (status == 0)
            {
                _globalPath = new List<Point>();
                grid.MouseLeftButtonDown +=new MouseButtonEventHandler(grid1_MouseLeftButtonDown);
                status = 1;
            }
            else
            {
                grid.MouseLeftButtonDown -= new MouseButtonEventHandler(grid1_MouseLeftButtonDown);
                World.GlobalAction = new BoidActionFollowPath(_globalPath);
                status = 0;
            }
        }

        void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UIElement element = sender as UIElement;
            World.AddBoid(e.GetPosition(element));
        }

        void grid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid element = sender as Grid;
            if(_globalPath.Count>0)
            {
                Line line = new Line();
                line.X2 = e.GetPosition(element).X;
                line.Y2 = e.GetPosition(element).Y;
                line.X1 = _globalPath.Last().X;
                line.Y1 = _globalPath.Last().Y;
                line.StrokeThickness = 4;
                line.Stroke = new SolidColorBrush(Color.FromArgb(255,0,255,255));

                element.Children.Add(line);
                   
            }
            _globalPath.Add(e.GetPosition(element));
        }
    }
}
