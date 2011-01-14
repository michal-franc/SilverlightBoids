﻿using System;
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
using SilverlightBoids.WorldLogic;

namespace SilverlightBoids
{
    public partial class MenuControl : UserControl
    {
        private IList<Point> _globalPath;
        public WorldLogic.World World { get; set; }
        public MenuControl()
        {
            InitializeComponent();
        }

        private void btnAddBoidRandom_Click(object sender, RoutedEventArgs e)
        {
            World.AddBoid();
        }

        /// <summary>
        /// Toogle Button Event for Add Boid Logic.
        /// </summary>
        private void btnAddBoid_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Add Boid";

            if (World.WorldStatus != WorldStatus.AddBoid)
            {
                World.Map.MouseLeftButtonDown += new MouseButtonEventHandler(grid_MouseLeftButtonDown);
                World.WorldStatus = WorldStatus.AddBoid;
            }
            else
            {
                World.Map.MouseLeftButtonDown -= new MouseButtonEventHandler(grid_MouseLeftButtonDown);
                World.WorldStatus = WorldStatus.None;
            }
        }

        private void btnFlee_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Flee";
            World.SetGlobalAction(WorldStatus.GlobalFlee);
            World.WorldStatus = WorldStatus.GlobalFlee;
        }

        private void btnSeek_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Seek";
            World.SetGlobalAction(WorldStatus.GlobalSeek);
            World.WorldStatus = WorldStatus.GlobalSeek;
        }


        /// <summary>
        /// Toggle button for Follow Patch Logic.
        /// </summary>
        private void btnFollowPath_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Follow Path";
            if (World.WorldStatus != WorldStatus.GlobalFollowPath)
            {
                _globalPath = new List<Point>();
                World.Map.MouseLeftButtonDown +=new MouseButtonEventHandler(grid1_MouseLeftButtonDown);
                World.WorldStatus = WorldStatus.GlobalFollowPath;
            }
            else
            {
                World.Map.MouseLeftButtonDown -= new MouseButtonEventHandler(grid1_MouseLeftButtonDown);
                World.GlobalPath = _globalPath;
                World.SetGlobalAction(WorldStatus.GlobalFollowPath);
                World.WorldStatus = WorldStatus.None;
            }
        }

        void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            UIElement element = sender as UIElement;
            World.AddBoid(e.GetPosition(element));
        }

        void grid1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(_globalPath.Count>0)
            {
                Line line = new Line();
                line.X2 = e.GetPosition(World.Map).X;
                line.Y2 = e.GetPosition(World.Map).Y;
                line.X1 = _globalPath.Last().X;
                line.Y1 = _globalPath.Last().Y;
                line.StrokeThickness = 1;
                line.Stroke = new SolidColorBrush(Color.FromArgb(255,0,255,255));

                World.Map.Children.Add(line);
                   
            }
            _globalPath.Add(e.GetPosition(World.Map));
        }

        private void AddColony_Checked(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Add colony...";

            //World.WorldStatus = WorldStatus.AddingColony;
            World.Map.MouseLeftButtonDown += new MouseButtonEventHandler(Map_MouseLeftButtonDown);
            
            
        }

        private void AddColony_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Collonies added";

            //World.WorldStatus = WorldStatus.None;
            World.Map.MouseLeftButtonDown -= new MouseButtonEventHandler(Map_MouseLeftButtonDown);
        }

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            World.AddColony(e.GetPosition(World.Map), Logic.Styles.Colors.GetColor());
        }

        private void AddRockObject_Checked(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Add rock(s)...";

            //World.WorldStatus = WorldStatus.AddingRockObject;
            World.Map.MouseLeftButtonDown += new MouseButtonEventHandler(Map_MouseLeftButtonDown_AddingNewRock);
        }

        private void AddRockObject_Unchecked(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Rocks added.";
            
            //World.WorldStatus = WorldStatus.None;
            World.Map.MouseLeftButtonDown -= new MouseButtonEventHandler(Map_MouseLeftButtonDown_AddingNewRock);
        }

        private void Map_MouseLeftButtonDown_AddingNewRock(object sender, MouseButtonEventArgs e)
        {
            World.AddRockObject(e.GetPosition(World.Map));
        }

        private void btnArrive_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Arrive";
            World.WorldStatus = WorldStatus.GlobalArrive;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnSeparate_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Separate";
            World.WorldStatus = WorldStatus.GlobalSeparate;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnCohesion_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Cohesion";
            World.WorldStatus = WorldStatus.GlobalCohesion;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnAligment_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "Aligment";
            World.WorldStatus = WorldStatus.GlobalAligment;
            World.SetGlobalAction(World.WorldStatus);
        }

        private void btnFCAS_Click(object sender, RoutedEventArgs e)
        {
            txtSelectedOption.Text = "FCAS";
            World.WorldStatus = WorldStatus.GlobalFCAS;
            World.SetGlobalAction(World.WorldStatus);
        }
    }
}
