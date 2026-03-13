// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Domain.Entities;

namespace Examples.Navigation.Horizontal.Application.Interfaces.Repositories;

/// <summary>
/// Defines a contract for a repository that manages <see cref="MenuFragment"/> entities.
/// </summary>
/// <remarks>
/// This interface extends <see cref="IRepository{MenuFragment}"/> to provide
/// data access operations specific to menu fragments within the application.
/// Implementations are responsible for CRUD operations and any additional
/// menu-specific data handling required by the domain.
/// </remarks>
public interface IMenuRepository : IRepository<MenuFragment>
{
}
