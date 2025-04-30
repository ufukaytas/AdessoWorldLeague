using AdessoWorldLeague.Application.Interfaces;
using AdessoWorldLeague.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdessoWorldLeague.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDrawService, DrawService>();
        return services;
    }
} 