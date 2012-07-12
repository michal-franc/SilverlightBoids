namespace SilverlightBoids.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;

    public static class Settings
    {
        public static class Redis
        {
            private static string GetValue(string key)
            {
                if (ConfigurationManager.AppSettings[key] != null)
                {
                    return ConfigurationManager.AppSettings[key];
                }
                else
                {
                    return String.Empty;
                }
            }

            public static bool UseLocalRedis
            {
                get { return Boolean.Parse(GetValue("UseLocalRedis")); }
            }

            public static string RedisLocalHost
            {
                get { return GetValue("RedisLocalHost"); }
            }

            public static string RedisExternalHost
            {
                get { return GetValue("RedisExternalHost"); }
            }

            public static string ExternalRedisPassword
            {
                get { return GetValue("ExternalRedisPassword"); }
            }
        }
    }

}