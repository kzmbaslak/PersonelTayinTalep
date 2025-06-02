using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;
        private readonly ConcurrentDictionary<string, byte> _cachedKeys;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
            _cachedKeys = new ConcurrentDictionary<string, byte>();

        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key,value,TimeSpan.FromSeconds(duration));
            _cachedKeys.TryAdd(key, 0); // 0 sadece bir dolgu değeridir

        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            _cachedKeys.TryRemove(key, out _);
        }

        public void RemoveByPattern(string pattern)//pattern [IUserService.Get] user service altında get içerenleri uçur
        {
            
            if (string.IsNullOrEmpty(pattern))
                return;

            
            var regex = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

            
            var keysSnapshot = _cachedKeys.Keys.ToList();

            foreach (var key in keysSnapshot)
            {
                if (regex.IsMatch(key))
                {
                    _memoryCache.Remove(key);
                    _cachedKeys.TryRemove(key, out _); 
                }
            }
        }
    }
}
