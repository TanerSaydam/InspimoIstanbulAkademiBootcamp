using StackExchange.Redis;
using System.Text.Json;
using IDatabase = StackExchange.Redis.IDatabase;

namespace eBiletServer.Application.Services;
public class RedisService
{
    public readonly IDatabase _redisDb;
    public RedisService()
    {
        var database = ConnectionMultiplexer.Connect("localhost:6379");
        _redisDb = database.GetDatabase();
    }

    public RedisValue Get(string key)
    {
        return _redisDb.StringGet(key);
    }

    public bool Set(string key, object value, int minute = 60)
    {
        string stringValue = JsonSerializer.Serialize(value);
        return _redisDb.StringSet(key, stringValue, TimeSpan.FromMinutes(minute));
    }

    public bool Delete(string key)
    {
       return _redisDb.KeyDelete(key);
    }
}
