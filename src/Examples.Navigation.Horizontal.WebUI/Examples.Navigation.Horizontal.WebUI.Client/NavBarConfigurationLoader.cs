// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Examples.Navigation.Horizontal.WebUI.Client;

internal static class NavBarConfigurationLoader
{
    public static async Task LoadAsync(WebAssemblyHostBuilder builder)
    {
        HttpClient http = new()
        {
            BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
        };
        _ = builder.Services.AddScoped(sp => http);
        using HttpResponseMessage response = await http.GetAsync("navBar.json");
        using Stream stream = await response.Content.ReadAsStreamAsync();
        _ = builder.Configuration.AddJsonStream(stream);
    }
}
