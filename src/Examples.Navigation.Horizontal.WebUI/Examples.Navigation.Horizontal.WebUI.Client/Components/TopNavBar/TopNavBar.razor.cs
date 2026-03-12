// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Services;
using Examples.Navigation.Horizontal.Domain.Entities;

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Client.Components.TopNavBar;

/// <summary>
///     Represents the top navigation bar component for the Blazor WebAssembly application.
///     This component is responsible for loading and displaying the menu structure,
///     as well as handling the navigation bar's collapsed/expanded state.
/// </summary>
public partial class TopNavBar : ComponentBase
{
    /// <summary>
    ///     Gets or sets the menu service used to retrieve the menu tree.
    ///     This service is injected by the Blazor dependency injection system.
    /// </summary>
    [Inject]
    private IMenuService MenuService { get; set; } = default!;

    [Inject]
    private IConfiguration Configuration { get; set; } = default!;

    private string _navBarTitle = string.Empty;

    /// <summary>
    ///     Holds the collection of menu items to be rendered in the navigation bar.
    /// </summary>
    private IEnumerable<MenuFragment> _menuItems = [];

    /// <summary>
    ///     Indicates whether the navigation bar is currently collapsed.
    /// </summary>
    private bool _isNavCollapsed = true;

    /// <summary>
    ///     Toggles the collapsed state of the navigation bar.
    /// </summary>
    private void ToggleNavMenu()
    {
        _isNavCollapsed = !_isNavCollapsed;
    }

    /// <summary>
    ///     Loads the menu items asynchronously when the component is initialized.
    ///     This method is called by the Blazor framework during component initialization.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        _menuItems = await MenuService.GetMenuTreeAsync();
        _navBarTitle = Configuration["NavBar:Title"] ?? "Navigation";
    }
}