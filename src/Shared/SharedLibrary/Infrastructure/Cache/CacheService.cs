namespace SharedLibrary.Infrastructure.Cache;

using SharedLibrary.Core.Application.Cache;
using SharedLibrary.Core.Application.Enums;
using StackExchange.Redis;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _database;

    public RedisCacheService(string connectionString)
    {
        var redis = ConnectionMultiplexer.Connect(connectionString);
        _database = redis.GetDatabase();
    }

    public bool TryGetValue(string key, out string value)
    {
        var redisValue = _database.StringGet(key);
        if (redisValue.HasValue)
        {
            value = redisValue;
            return true;
        }

        value = null;
        return false;
    }

    public void Set(string key, string value)
        => _database.StringSet(key, value);

    public void Set(string key, string value, TimeSpan expiration)
        => _database.StringSet(key, value, expiration);

    public bool Remove(string key)
        => _database.KeyDelete(key);

    public void SetMultiple(Dictionary<string, string> keyValuePairs, ECultureType eCultureType)
    {
        var redisKeyValuePairs = keyValuePairs.Select(kvp =>
            new KeyValuePair<RedisKey, RedisValue>($"{kvp.Key}_{eCultureType}", kvp.Value)).ToArray();

        _database.StringSet(redisKeyValuePairs);

    }


}
