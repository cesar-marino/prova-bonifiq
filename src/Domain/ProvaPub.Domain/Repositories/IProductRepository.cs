using ProvaPub.Domain.Entities;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<IReadOnlyList<ProductEntity>> FindAllAsync(
            int page,
            int perPage,
            CancellationToken cancellationToken = default);
    }
}
