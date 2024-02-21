using EntityFrameworkCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Personel> Personels { get; set; }
}