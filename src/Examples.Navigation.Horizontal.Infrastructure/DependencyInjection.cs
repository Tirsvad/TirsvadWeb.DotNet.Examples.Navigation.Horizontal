// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application;
using Examples.Navigation.Horizontal.Application.Interfaces.Repositories;
using Examples.Navigation.Horizontal.Infrastructure.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace Examples.Navigation.Horizontal.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to register infrastructure services in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        _ = services.AddApplicationServices();

        // Register repositories
        _ = services.AddScoped<IMenuRepository, MenuRepository>();

        // Register other infrastructure services here, e.g.:
        // services.AddScoped<IMenuService, MenuService>();

        return services;
    }
}
