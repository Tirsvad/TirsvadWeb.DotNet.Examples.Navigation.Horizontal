// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Domain.Interfaces;

namespace Examples.Navigation.Horizontal.Domain.Entities;

public class MenuFragment : IEntity
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Url { get; set; } = string.Empty;
    public string? FontClassEmoji { get; set; }
    public int Order { get; set; }
    public Guid? ParentId { get; set; }

    #region Navigation Properties
    public virtual ICollection<MenuFragment>? Children { get; set; }
    #endregion
}
