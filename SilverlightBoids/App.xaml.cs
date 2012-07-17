namespace SilverlightBoids
{
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

    public partial class App : Application
    {
        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
            this.UnhandledException += this.Application_UnhandledException;

            this.InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            WCFLogger.Trace("Application Startup");
            Grid root = new Grid();
            this.RootVisual = root;
            root.Children.Add(new StartPage()); 
        }

        private void Application_Exit(object sender, EventArgs e)
        {
            WCFLogger.Trace("Application Exit");
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            WCFLogger.ErrorExceptionsWithInner("Unhandled Exception\r\n", e.ExceptionObject);
        }
    }
}
