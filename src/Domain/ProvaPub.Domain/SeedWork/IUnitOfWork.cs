﻿namespace ProvaPub.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
