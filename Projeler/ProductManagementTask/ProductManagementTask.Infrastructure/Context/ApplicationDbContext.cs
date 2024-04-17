using Microsoft.EntityFrameworkCore;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Enums;

namespace ProductManagementTask.Infrastructure.Context;
internal sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<StockType> StockTypes { get; set; }
    public DbSet<StockUnit> StockUnits { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stock>()
            .Property(p => p.StockClass)
            .HasConversion(stock => stock.Value, value => StockClassEnum.FromValue(value));        

        modelBuilder.Entity<StockUnit>()
            .Property(p=> p.QuantityUnit)
            .HasConversion(unit => unit.Value, value => QuantityUnitEnum.FromValue(value));

        modelBuilder.Entity<StockUnit>()
            .OwnsOne(p => p.Buying, buyingBuilder =>
            {
                buyingBuilder
                .Property(p => p.Currency)
                .HasConversion(currency => currency.Value, value => MoneyTypeEnum.FromValue(value))
                .HasColumnName("Currency");

                buyingBuilder
                .Property(p => p.Amount)
                .HasColumnName("Amount")
                .HasColumnType("money");
            });
    }
}
