// Copyright (c) 2026 TirsvadWeb. All rights reserved.
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Domain.Entities;

namespace Examples.Navigation.Horizontal.Application.Interfaces.Services;

/// <summary>
/// Provides operations for retrieving and managing the application's menu structure.
/// </summary>
/// <remarks>
/// This service abstracts menu retrieval logic, supporting both in-memory and JSON-based sources.
/// </remarks>
public interface IMenuService
{
    /// <summary>
    /// Asynchronously retrieves the complete menu tree, including all fragments and their nested children.
    /// </summary>
    /// <remarks>
    /// This method loads the menu structure from the application's primary data source.
    /// </remarks>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="MenuFragment"/> objects representing the menu tree.
    /// </returns>
    /// <example>
    /// <code language="csharp">
    /// var menuService = ...; // Get IMenuService instance via DI
    /// var menuTree = await menuService.GetMenuTreeAsync();
    /// </code>
    /// </example>
    Task<IEnumerable<MenuFragment>> GetMenuTreeAsync();

    /// <summary>
    /// Asynchronously retrieves the menu tree from a specified JSON file, including all fragments and their nested children.
    /// </summary>
    /// <param name="jsonFilePath">
    /// A relative or absolute path to the JSON file containing the menu definition. Defaults to <c>mainMenu.json</c>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="MenuFragment"/> objects representing the menu tree.
    /// </returns>
    /// <remarks>
    /// Use this method to load menu definitions from external or custom JSON files.
    /// </remarks>
    /// <example>
    /// <code language="csharp">
    /// var menuService = ...; // Get IMenuService instance via DI
    /// var menuTree = await menuService.GetMenuTreeFromJsonAsync("customMenu.json");
    /// </code>
    /// </example>
    Task<IEnumerable<MenuFragment>> GetMenuTreeFromJsonAsync(string jsonFilePath = "mainMenu.json");
}
