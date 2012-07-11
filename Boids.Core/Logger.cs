namespace Boids.Core
{
    using System.Windows.Controls;
    using System.Text;

    public static class Logger
    {
        private static string fileName = "log.txt";

        public static void Save(StringBuilder sb)
        {
            LogDestination.Text += sb.ToString();
        }

        public static TextBlock LogDestination { get; set; }
    }
}
