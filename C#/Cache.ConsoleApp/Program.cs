using Cache.ConsoleApp;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Text.Json;

Console.WriteLine("Cache Yöntemleri");

var services = new ServiceCollection();

services.AddMemoryCache();

var scoped = services.BuildServiceProvider();

IMemoryCache memoryCache = scoped.GetRequiredService<IMemoryCache>();

var connection = ConnectionMultiplexer.Connect("localhost:6379");
IDatabase redisDb = connection.GetDatabase();

memoryCache.Remove("products");
redisDb.KeyDelete("products");

while (true)
{
    List<Product>? products;
    //products = memoryCache.Get<List<Product>>("products");
    RedisValue redisValue = redisDb.StringGet("products");
    if (redisValue.IsNull)
    {
        products = Product.GetAll();
        redisDb.StringSet("products",JsonSerializer.Serialize(products),TimeSpan.FromSeconds(30));
        //memoryCache.Set<List<Product>>("products", products, TimeSpan.FromSeconds(30));
    }
    else
    {
        products = JsonSerializer.Deserialize<List<Product>>(redisValue);
    }

    foreach (var product in products)
    {
        Console.WriteLine($"Product Name: {product.Name} - Price: {product.Price}");
        //Console.WriteLine("Product Name: {0} - Price: {1}",product.Name, product.Price);
    }

    Console.WriteLine("Devam etmek için bir tuşa basın");
    Console.ReadLine();
}