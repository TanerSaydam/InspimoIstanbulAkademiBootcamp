using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagerServer.Domain.Entities;

namespace TaskManagerServer.Infrastructure.Configurations;
internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(p => p.FirstName).HasColumnType("varchar(50)");
        builder.Property(p => p.LastName).HasColumnType("varchar(50)");
    }
}
