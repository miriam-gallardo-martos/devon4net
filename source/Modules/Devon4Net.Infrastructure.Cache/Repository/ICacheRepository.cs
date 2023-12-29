namespace Devon4Net.Infrastructure.Cache.Repository
{
    public interface ICacheRepository
    {
        Task<T?> GetData<T>(string key);
        Task SetData<T>(string key, T value);
        Task RemoveData(string key);
    }
}
