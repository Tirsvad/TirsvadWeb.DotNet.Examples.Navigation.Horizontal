// Copyright (c) 2026 TirsvadWeb. All rights reserved.
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Repositories;
using Examples.Navigation.Horizontal.Application.Interfaces.Services;
using Examples.Navigation.Horizontal.Domain.Entities;

namespace Examples.Navigation.Horizontal.Application.Services;

/// <summary>
/// Provides operations for retrieving and managing menu fragments.
/// </summary>
/// <remarks>
/// Implements <see cref="IMenuService"/> and orchestrates menu data retrieval from repositories.
/// </remarks>
/// <remarks>
/// Initializes a new instance of the <see cref="MenuService"/> class.
/// </remarks>
/// <param name="menuRepository">An instance of a menu repository for data access.</param>
public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private readonly IMenuRepository _menuRepository = menuRepository;

    /// <summary>
    /// Asynchronously retrieves the menu tree from the repository.
    /// </summary>
    /// <remarks>
    /// This method fetches all menu fragments from the underlying data source using the injected repository.
    /// </remarks>
    /// <returns>
    /// An asynchronous operation that returns a collection of <see cref="MenuFragment"/> representing the menu tree.
    /// </returns>
    /// <example>
    /// <code language="csharp">
    /// var menuService = new MenuService(menuRepository);
    /// var menuTree = await menuService.GetMenuTreeAsync();
    /// </code>
    /// </example>
    public async Task<IEnumerable<MenuFragment>> GetMenuTreeAsync()
    {
        return await _menuRepository.GetAllAsync();
    }

    /// <summary>
    /// Asynchronously retrieves the menu tree from a JSON file.
    /// </summary>
    /// <param name="jsonFilePath">
    /// A relative or absolute path to the JSON file containing menu data. The default is <c>mainMenu.json</c>.
    /// </param>
    /// <returns>
    /// An asynchronous operation that returns a collection of <see cref="MenuFragment"/> parsed from the specified JSON file.
    /// </returns>
    /// <exception cref="NotImplementedException">
    /// The method is not yet implemented.
    /// </exception>
    /// <example>
    /// <code language="csharp">
    /// var menuService = new MenuService(menuRepository);
    /// var menuTree = await menuService.GetMenuTreeFromJsonAsync("customMenu.json");
    /// </code>
    /// </example>
    public Task<IEnumerable<MenuFragment>> GetMenuTreeFromJsonAsync(string jsonFilePath = "mainMenu.json")
    {
        throw new NotImplementedException();
    }
}
