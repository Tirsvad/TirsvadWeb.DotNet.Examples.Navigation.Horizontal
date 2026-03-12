// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Infrastructure;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Examples.Navigation.Horizontal.WebUI.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

        _ = builder.Services.AddInfrastructureServices();

        // Load the navigation bar configuration from the navBar.json file and add it to the configuration system.
        await NavBarConfigurationLoader.LoadAsync(builder);

        await builder.Build().RunAsync();
    }
}
