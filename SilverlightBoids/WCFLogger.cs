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

namespace SilverlightBoids
{
    using SilverlightBoids.LoggingService;

    public static class WCFLogger
    {
        public static LoggingServiceClient logClient = new LoggingServiceClient();


        public static void Info(string message,params object[] values)
        {
            logClient.InfoAsync(string.Format(message, values));
        }

        public static void Warn(string message, params object[] values)
        {
            logClient.WarnAsync(string.Format(message, values));
        }

        public static void Error(string message, params object[] values)
        {
            logClient.ErrorAsync(string.Format(message, values));
        }

        public static void Trace(string message, params object[] values)
        {
            logClient.TraceAsync(string.Format(message, values));
        }

        public static void Fatal(string message, params object[] values)
        {
            logClient.FatalAsync(string.Format(message, values));
        }

        public static void Debug(string message, params object[] values)
        {
            logClient.DebugAsync(string.Format(message,values));
        }
    }
}
