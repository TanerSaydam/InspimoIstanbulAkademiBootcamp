using Microsoft.EntityFrameworkCore;

namespace PersonelServer.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}