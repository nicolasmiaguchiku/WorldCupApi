namespace WorldCup.Domain.Interface.Services
{
    public interface IMemoryCacheService
    {
        T? Get<T>(string ke);
        void Set<T>(string key, T value);
        void Remove(string key);
    }
}