using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {        
    }
}
