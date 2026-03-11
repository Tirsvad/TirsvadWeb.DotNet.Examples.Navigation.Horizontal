// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Domain.Entities;

namespace Examples.Navigation.Horizontal.Application.Interfaces.Services;

public interface IMenuService
{
    Task<IEnumerable<MenuFragment>> GetMenuTreeAsync();
}
