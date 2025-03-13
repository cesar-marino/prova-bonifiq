namespace ProvaPub.Domain.SeedWork
{
    public interface ISearchableRepository<TEntity>
    {
        Task<IReadOnlyList<TEntity>> FindAllAsync(
            int page,
            int perPage,
            CancellationToken cancellationToken = default);
    }
}
