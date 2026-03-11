// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Services;
using Examples.Navigation.Horizontal.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Examples.Navigation.Horizontal.Application;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to register application services in the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register application services here, e.g.:
        _ = services.AddScoped<IMenuService, MenuService>();

        return services;
    }
}
