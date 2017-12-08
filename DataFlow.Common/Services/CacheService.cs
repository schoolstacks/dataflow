using System;
using System.Collections.Generic;
using System.Linq;
using CacheManager.Core;
using CacheManager.Core.Internal;

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

        public void Clear()
        {
            _cacheManager.Clear();
        }

        public List<string> GetStats()
        {
            return _cacheManager.CacheHandles.Select(handle => handle.Stats)
                .Select(stats => string.Format("Items: {0}, Hits: {1}, Miss: {2}, Remove: {3}, ClearRegion: {4}, Clear: {5}, Adds: {6}, Puts: {7}, Gets: {8}",
                    stats.GetStatistic(CacheStatsCounterType.Items),
                    stats.GetStatistic(CacheStatsCounterType.Hits),
                    stats.GetStatistic(CacheStatsCounterType.Misses),
                    stats.GetStatistic(CacheStatsCounterType.RemoveCalls),
                    stats.GetStatistic(CacheStatsCounterType.ClearRegionCalls),
                    stats.GetStatistic(CacheStatsCounterType.ClearCalls),
                    stats.GetStatistic(CacheStatsCounterType.AddCalls),
                    stats.GetStatistic(CacheStatsCounterType.PutCalls),
                    stats.GetStatistic(CacheStatsCounterType.GetCalls)))
                .ToList();
        }

        public void Dispose()
        {
           _cacheManager.Dispose();
        }
    }
}