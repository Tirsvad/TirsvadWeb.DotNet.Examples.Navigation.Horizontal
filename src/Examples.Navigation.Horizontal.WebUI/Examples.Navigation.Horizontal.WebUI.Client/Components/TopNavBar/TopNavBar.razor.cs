// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Services;
using Examples.Navigation.Horizontal.Domain.Entities;

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Client.Components.TopNavBar;

public partial class TopNavBar
{
    [Inject]
    private IMenuService MenuService { get; set; } = default!;

    private IEnumerable<MenuFragment> _menuItems = [];

    /// <summary>
    /// Indicates whether the navigation menu is collapsed (for responsive layouts).
    /// </summary>
    private bool collapseNavMenu = true;

    /// Gets the CSS class for the navigation bar container, adding 'show' when expanded.
    /// </summary>
    private string NavBarCssClass => $"collapse navbar-collapse{(collapseNavMenu ? string.Empty : " show")}";

    /// <summary>
    /// Gets the CSS class for the navigation toggle button, 'collapsed' when menu is collapsed.
    /// </summary>
    private string? NavButtonCssClass => collapseNavMenu ? "collapsed" : string.Empty;

    /// <summary>
    /// Tracks the set of open submenu IDs to manage their expanded/collapsed state.
    /// </summary>
    private readonly HashSet<Guid> openSubmenus = [];

    /// <summary>
    /// Loads the menu items asynchronously when the component is initialized.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        _menuItems = await MenuService.GetMenuTreeAsync();
    }

    /// <summary>
    /// Toggles the collapsed state of the main navigation menu (for mobile/responsive).
    /// </summary>
    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}