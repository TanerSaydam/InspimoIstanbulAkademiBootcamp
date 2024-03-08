using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Validators;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(typeof(VehicleDtoValidator).Assembly);

        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehicleService, VehicleService>();
        return services;
    }
}
