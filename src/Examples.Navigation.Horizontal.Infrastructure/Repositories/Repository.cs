// Copyright (c) 2026 TirsvadWeb. All rights reserved. 
//  No warranty, explicit or implicit, provided.

using Examples.Navigation.Horizontal.Application.Interfaces.Repositories;
using Examples.Navigation.Horizontal.Domain.Interfaces;

namespace Examples.Navigation.Horizontal.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    public IEnumerable<TEntity> Items => throw new NotImplementedException();

    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _ = Items.Append(entity);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _ = Items.Concat(entities);
        return Task.FromResult(entities);
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _ = Items.Where(e => e != entity);
        return Task.CompletedTask;
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _ = Items.Where(e => !entities.Contains(e));
        return Task.CompletedTask;
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Items);
    }

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        TEntity? entity = Items.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(entity);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _ = Items.Select(e => e == entity ? entity : e);
        return Task.CompletedTask;
    }

    public Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _ = Items.Select(e => entities.Contains(e) ? e : e);
        return Task.CompletedTask;
    }
}
