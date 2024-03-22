using Bogus;

namespace Cache.ConsoleApp;
public sealed class Product
{
    public Product()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public static List<Product> GetAll()
    {
        List<Product> products = new();
        for (int i = 0; i < 100; i++)
        {
            Faker faker = new();
            products.Add(new()
            {
                Name = faker.Commerce.ProductName(),
                Price = Convert.ToDecimal(faker.Commerce.Price())
            });            
        }

        return products;
    }
}
