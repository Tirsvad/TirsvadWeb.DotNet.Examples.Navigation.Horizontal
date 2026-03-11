// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Components;

public partial class App
{
    [Inject]
    private IWebHostEnvironment Environment { get; set; } = default!;
    private bool IsDebug => Environment.IsDevelopment();
}