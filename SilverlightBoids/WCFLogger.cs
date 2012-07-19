namespace SilverlightBoids
{
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
    using SilverlightBoids.LoggingService;

    public static class WCFLogger
    {
        private static readonly LoggingServiceClient LogClient = new LoggingServiceClient();

        public static string ExtractInnerException(Exception ex)
        {
            var innerException = string.Empty;
            if (ex.InnerException != null)
            {
                innerException = ExtractInnerException(ex.InnerException);
            }

            return string.Format("{0} \r\n   {1}", ex.Message, innerException);
        }

        public static void ErrorExceptionsWithInner(string message, Exception ex)
        {
            var innerExceptions = string.Empty;
            if (ex.InnerException != null)
            {
                innerExceptions = ExtractInnerException(ex.InnerException);
            }

            LogClient.ErrorAsync(string.Format("{0} Exception\r\n {1} \r\n--------------\r\n {2}", message, ex.Message, innerExceptions));
        }

        public static void Info(string message, params object[] values)
        {
            LogClient.InfoAsync(string.Format(message, values));
        }

        public static void Warn(string message, params object[] values)
        {
            LogClient.WarnAsync(string.Format(message, values));
        }

        public static void Error(string message, params object[] values)
        {
            LogClient.ErrorAsync(string.Format(message, values));
        }

        public static void Trace(string message, params object[] values)
        {
            LogClient.TraceAsync(string.Format(message, values));
        }

        public static void Fatal(string message, params object[] values)
        {
            LogClient.FatalAsync(string.Format(message, values));
        }

        public static void Debug(string message, params object[] values)
        {
            LogClient.DebugAsync(string.Format(message, values));
        }
    }
}
