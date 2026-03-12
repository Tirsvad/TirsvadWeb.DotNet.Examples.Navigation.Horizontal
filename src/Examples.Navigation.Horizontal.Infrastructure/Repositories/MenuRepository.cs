// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Repositories;
using Examples.Navigation.Horizontal.Domain.Entities;

using Microsoft.Extensions.Configuration;

namespace Examples.Navigation.Horizontal.Infrastructure.Repositories;

public class MenuRepository : RepositoryBase<MenuFragment>, IMenuRepository
{
    private readonly IConfiguration _configuration;

    public MenuRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        SeedData();

        // Ensure top-level items are ordered correctly
        Items = [.. Items.OrderBy(m => m.Order)];

        // Add children to their parents
        Dictionary<Guid, MenuFragment> menuDict = Items.ToDictionary(m => m.Id);
        foreach (MenuFragment menu in Items)
        {
            if (menu.ParentId.HasValue && menuDict.TryGetValue(menu.ParentId.Value, out MenuFragment? parent))
            {
                parent.Children ??= [];
                parent.Children.Add(menu);
            }
        }
    }

    private void SeedData()
    {
        // Load NavItems from configuration (navBar.json)
        IConfigurationSection navItemsSection = _configuration.GetSection("NavItems");
        if (!navItemsSection.Exists())
        {
            return;
        }

        // Deserialize NavItems into a dynamic object to handle hierarchy
        IEnumerable<IConfigurationSection> navItems = navItemsSection.GetChildren();
        if (!navItems.Any())
        {
            return;
        }

        List<MenuFragment> menuFragments = [];
        void ParseNavItems(IEnumerable<IConfigurationSection> items, Guid? parentId = null)
        {
            foreach (IConfigurationSection item in items)
            {
                MenuFragment menu = new()
                {
                    Id = Guid.Parse(item["Id"]!),
                    Title = item["Title"]!,
                    Url = item["Url"],
                    Order = int.TryParse(item["Order"], out int order) ? order : 0,
                    ParentId = parentId,
                    IsVisible = item["IsVisible"] == null || bool.Parse(item["IsVisible"]!),
                    IsEnabled = item["IsEnabled"] == null || bool.Parse(item["IsEnabled"]!),
                    FontClassEmoji = item["FontClassEmoji"]
                };
                menuFragments.Add(menu);
                IEnumerable<IConfigurationSection> subItems = item.GetSection("SubItems").GetChildren();
                if (subItems.Any())
                {
                    ParseNavItems(subItems, menu.Id);
                }
            }
        }

        ParseNavItems(navItems);

        // Add all menu fragments to the repository
        foreach (MenuFragment menu in menuFragments)
        {
            _ = AddAsync(menu);
        }
    }
}

