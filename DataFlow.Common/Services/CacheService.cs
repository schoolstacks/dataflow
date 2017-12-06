using System;
using CacheManager.Core;

namespace DataFlow.Common.Services
{
    public class CacheService : ICacheService, IDisposable
    {
        public string Name { get; }

        private readonly ICacheManagerConfiguration _configuration;
        private readonly ICacheManager<string> _cacheManager;

        public CacheService(ICacheManagerConfiguration configuration, ICacheManager<string> cacheManager)
        {
            this._configuration = configuration;
            this._cacheManager = cacheManager;

            this.Name = _configuration.Name;
        }

        public string Get(string keyName)
        {
            return _cacheManager.Get(keyName);
        }

        public string GetOrAdd(string keyName, string keyValue)
        {
            return _cacheManager.GetOrAdd(keyName, keyValue);
        }

        public bool Add(string keyName, string keyValue)
        {
            return _cacheManager.Add(keyName, keyValue);
        }

        public string AddOrUpdate(string keyName, string keyValue)
        {
            return _cacheManager.AddOrUpdate(keyName, keyValue, x=>keyValue);
        }

        public bool Exists(string keyName)
        {
            return _cacheManager.Exists(keyName);
        }

        public bool Remove(string keyName)
        {
            return _cacheManager.Remove(keyName);
        }

        public void Expire(string keyName, TimeSpan expireTimeSpan)
        {
            _cacheManager.Expire(keyName, expireTimeSpan);
        }

        public void Dispose()
        {
           _cacheManager.Dispose();
        }
    }
}