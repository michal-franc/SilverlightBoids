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
using System.Windows.Navigation;

namespace SilverlightBoids
{
    public enum Option
    {
        Custom,
        Wander,
        FCAS,
        Separater,
        Cohesion
    }

    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnLoadWander_Click(object sender, RoutedEventArgs e)
        {
            ChangeToMainPage(Option.Wander);
        }

        private void btnLoadFCAS_Click(object sender, RoutedEventArgs e)
        {
            ChangeToMainPage(Option.FCAS);
        }

        private void btnLoadSeparate_Click(object sender, RoutedEventArgs e)
        {
            ChangeToMainPage(Option.Separater);
        }

        private void btnLoadCohesion_Click(object sender, RoutedEventArgs e)
        {
            ChangeToMainPage(Option.Cohesion);
        }

        private void btnLoadCustom_Click(object sender, RoutedEventArgs e)
        {
            ChangeToMainPage(Option.Custom);
        }

        private void ChangeToMainPage(Option option)
        {
            Grid root = Application.Current.RootVisual as Grid;
            root.Children.RemoveAt(0);   
            root.Children.Add(new MainPage(option));
        }
    }
}
