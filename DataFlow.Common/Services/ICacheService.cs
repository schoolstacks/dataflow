using System;

namespace DataFlow.Common.Services
{
    public interface ICacheService
    {
        string Name { get; }
        string Get(string keyName);
        string GetOrAdd(string keyName, string keyValue);
        bool Add(string keyName, string keyValue);
        string AddOrUpdate(string keyName, string keyValue);
        bool Exists(string keyName);
        bool Remove(string keyName);
        void Dispose();
        void Expire(string keyName, TimeSpan expireTimeSpan);
    }
}
