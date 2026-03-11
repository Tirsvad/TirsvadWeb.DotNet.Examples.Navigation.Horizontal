// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using System.Diagnostics;

using Examples.Navigation.Horizontal.Domain.Entities;

using Microsoft.AspNetCore.Components;

namespace Examples.Navigation.Horizontal.WebUI.Client.Components.TopNavBar;

public partial class MenuFragmentRender
{
    [Parameter]
    public MenuFragment MenuFragment { get; set; } = default!;

    [Parameter]
    public int MenuLevel { get; set; } = 0;

    private string Link => MenuFragment.Url ?? "#";
    private bool HasChildren => MenuFragment.Children != null && MenuFragment.Children.Count > 0;
    private string Title => MenuFragment.Title ?? "Untitled";
    private string FontClassEmoji => MenuFragment.FontClassEmoji ?? "";
    private bool HasParent => MenuFragment.ParentId != null;
    private bool HasFontClassEmoji => MenuFragment.FontClassEmoji is not null;

    private string GetCssClassForA()
    {
        return HasParent
            ? HasChildren ? "dropdown-item dropdown-toggle" : "nav-link"
            : HasChildren ? "nav-link dropdown-toggle" : "nav-link";
    }

    private string GetCssClassForLi()
    {
        return HasChildren
            ? MenuLevel == 0 ? "nav-item dropdown" : "dropdown-submenu"
            : MenuLevel == 0 ? "nav-item" : "";
    }
    /// <summary>
    /// Indicates whether the navigation menu is collapsed (for responsive layouts).
    /// </summary>
    private bool collapseNavMenu = true;

    /// <summary>
    /// Gets the CSS class for the navigation bar container, adding 'show' when expanded.
    /// </summary>
    private string NavBarCssClass => $"collapse navbar-collapse{(collapseNavMenu ? string.Empty : " show")}";

    /// <summary>
    /// Gets the CSS class for the navigation toggle button, 'collapsed' when menu is collapsed.
    /// </summary>
    private string? NavButtonCssClass => collapseNavMenu ? "collapsed" : string.Empty;

    private static bool IsSubMenuOpen(Guid id)
    {
        return openSubmenus.Contains(id);
    }

    private static string GetUlSubMenuCssClass(Guid id)
    {
        return IsSubMenuOpen(id) ? "dropdown-menu dropend show" : "dropdown-menu dropend";
    }

    private string GetAriaExpanded(Guid id)
    {
        return IsSubMenuOpen(id) ? "true" : "false";
    }

    /// <summary>
    /// Tracks the set of open submenu IDs to manage their expanded/collapsed state.
    /// </summary>
    private static readonly HashSet<Guid> openSubmenus = [];

    /// <summary>
    /// Toggles the collapsed state of the main navigation menu (for mobile/responsive).
    /// </summary>
    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    /// <summary>
    /// Opens a submenu by adding its ID to the open set.
    /// Called on mouse hover or click.
    /// </summary>
    /// <param name="id">The menu item's unique identifier.</param>
    private void OpenSubMenu(Guid id)
    {
        _ = openSubmenus.Add(id);
        StateHasChanged();
    }

    /// <summary>
    /// Closes a submenu by removing its ID from the open set.
    /// Called on mouse out.
    /// </summary>
    /// <param name="id">The menu item's unique identifier.</param>
    private void CloseSubMenu(Guid id)
    {
        _ = openSubmenus.Remove(id);
        StateHasChanged();
    }

    /// <summary>
    /// Toggles a submenu's open/closed state on click.
    /// </summary>
    /// <param name="id">The menu item's unique identifier.</param>
    private void ToggleSubMenu(Guid id)
    {
        Debug.WriteLine($"Toggling submenu with ID: {id}");
        StateHasChanged();
    }
}