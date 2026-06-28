using Microsoft.Extensions.Caching.Memory;
using WorldCup.Domain.Interface.Services;

namespace WorldCup.Infrastructure.Services
{
    public class MemoryCacheService(IMemoryCache cache) : IMemoryCacheService
    {
        private static readonly MemoryCacheEntryOptions DefaultOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10), // Expira SEMPRE não importa quantas vezes foi acessado
            SlidingExpiration = TimeSpan.FromMinutes(2), // Renova o tempo a cada acesso
            Size = 1 // Precisa ser declarado caso for usado a config 'SizeLimit'
        };

        public T? Get<T>(string key)
        {
            return cache.TryGetValue(key, out T? value) ? value : default;
        }

        public void Set<T>(string chave, T value)
        {
            cache.Set(chave, value, DefaultOptions);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}