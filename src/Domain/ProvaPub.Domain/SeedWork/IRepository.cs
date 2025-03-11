namespace ProvaPub.Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<IReadOnlyList<TEntity>> FindAll(CancellationToken cancellationToken = default);
        Task<TEntity> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
