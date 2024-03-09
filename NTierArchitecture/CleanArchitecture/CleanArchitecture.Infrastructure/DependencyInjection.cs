using CleanArchitecture.Application.Validators;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories;
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

        services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(typeof(VehicleDtoValidator).Assembly);

        services.AddScoped<IVehicleRepository, VehicleRepository>();        
        return services;
    }
}
