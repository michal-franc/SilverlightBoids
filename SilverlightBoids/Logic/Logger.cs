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
using System.IO;
using System.Text;

namespace SilverlightBoids.Logic
{
    public static class Logger
    {
        private static string fileName = "log.txt";

        public static void Save(StringBuilder sb)
        {
            LogPage.Text += sb.ToString();
        }

        public static TextBlock LogPage { get; set; }
    }
}
