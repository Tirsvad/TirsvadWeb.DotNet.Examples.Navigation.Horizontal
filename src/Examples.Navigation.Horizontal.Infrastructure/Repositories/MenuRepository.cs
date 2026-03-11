// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Repositories;
using Examples.Navigation.Horizontal.Domain.Entities;

namespace Examples.Navigation.Horizontal.Infrastructure.Repositories;

public class MenuRepository : RepositoryBase<MenuFragment>, IMenuRepository
{
    public MenuRepository()
    {
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
        // Top level menu items
        MenuFragment home = new() { Id = Guid.Parse("8fdd56d5-fd85-46cb-9c75-5192aca81dc2"), Title = "Home", Url = "/", Order = 1 };
        MenuFragment Menu_1 = new() { Id = Guid.Parse("d1c9e5b8-3a2f-4c9e-8b6a-1f2e3d4c5b6a"), Title = "Menu 1", Url = "/#", Order = 2 };
        MenuFragment about = new() { Id = Guid.Parse("65eb3faa-785a-4642-a45c-435103378666"), Title = "About", Url = "/about", Order = 3 };

        // Sub-menu items for Menu 1
        MenuFragment submenu1 = new() { Id = Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"), Title = "Submenu 1_1", Url = "/#", ParentId = Menu_1.Id, Order = 1 };
        MenuFragment submenu2 = new() { Id = Guid.Parse("b1c2d3e4-f5a6-7b8c-9d0e-1f2a3b4c5d6e"), Title = "Submenu 1_2", Url = "/#", ParentId = Menu_1.Id, Order = 2 };
        // Sub-menu for submenu1
        MenuFragment submenu1_1 = new() { Id = Guid.Parse("c1d2e3f4-a5b6-7c8d-9e0f-1a2b3c4d5e6f"), Title = "submenu 1_1_1", Url = "/#", ParentId = submenu1.Id, Order = 1 };
        // Sub-menu for subsubmenu1
        MenuFragment submenu1_1_1 = new() { Id = Guid.Parse("d1e2f3a4-b5c6-7d8e-9f0a-1b2c3d4e5f6a"), Title = "Subsubsubmenu 1_1_1_1", Url = "/#", ParentId = submenu1_1.Id, Order = 1 };

        // Add to repository
        _ = AddAsync(home);
        _ = AddAsync(Menu_1);
        _ = AddAsync(about);
        _ = AddAsync(submenu1);
        _ = AddAsync(submenu2);
        _ = AddAsync(submenu1_1);
        _ = AddAsync(submenu1_1_1);
    }
}
