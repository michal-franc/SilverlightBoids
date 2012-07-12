namespace SilverlightBoids.Web.RedisDal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ServiceStack.CacheAccess;
    using ServiceStack.Redis;

    public static class RedisDal
    {
        public static IRedisClientsManager GetClient()
        {
            if (Settings.Redis.UseLocalRedis)
                return new PooledRedisClientManager(Settings.Redis.RedisLocalHost);
            else
                return new RedisClientManagerPassword(Settings.Redis.ExternalRedisPassword, Settings.Redis.RedisExternalHost);

        }
    }

    public class RedisClientManagerPassword : IRedisClientsManager
    {
        private readonly string _password;
        private readonly string _host;

        public RedisClientManagerPassword(string password, string host)
        {
            _password = password;
            _host = host;

        }

        private IRedisClient CreateClient()
        {
            var hosts = _host.Split(':');
            var client = new RedisClient(hosts[0], Int32.Parse(hosts[1]));
            client.Password = _password;
            return client;
        }

        public bool IsServerAlive()
        {
            return ((RedisNativeClient)CreateClient()).Ping();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IRedisClient GetClient()
        {
            return CreateClient();
        }

        public IRedisClient GetReadOnlyClient()
        {
            throw new NotImplementedException();
        }

        public ICacheClient GetCacheClient()
        {
            throw new NotImplementedException();
        }

        public ICacheClient GetReadOnlyCacheClient()
        {
            throw new NotImplementedException();
        }
    }
}
