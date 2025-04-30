using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Infrastructure.Persistence.Context;
using AdessoWorldLeague.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoWorldLeague.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {

        // TODO: Add real database SQL SERVER
       // services.AddDbContext<AdessoDbContext>(options =>
       //     options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddDbContext<AdessoDbContext>(options =>
            options.UseInMemoryDatabase("AdessoWorldLeagueDb"));

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IDrawRepository, DrawRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        

        return services;
    }
}