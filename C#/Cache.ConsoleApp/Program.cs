using Cache.ConsoleApp;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

Console.WriteLine("Cache Yöntemleri");

var services = new ServiceCollection();

services.AddMemoryCache();

var scoped = services.BuildServiceProvider();

IMemoryCache memoryCache = scoped.GetRequiredService<IMemoryCache>();

while (true)
{
    List<Product>? products;
    products = memoryCache.Get<List<Product>>("products");
    if (products is null)
    {
        products = Product.GetAll();
        memoryCache.Set<List<Product>>("products", products, TimeSpan.FromSeconds(30));
    }

    foreach (var product in products)
    {
        Console.WriteLine($"Product Name: {product.Name} - Price: {product.Price}");
        //Console.WriteLine("Product Name: {0} - Price: {1}",product.Name, product.Price);
    }

    Console.WriteLine("Devam etmek için bir tuşa basın");
    Console.ReadLine();
}