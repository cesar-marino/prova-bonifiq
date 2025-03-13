using ProvaPub.Domain.Entities;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        Task<IReadOnlyList<CustomerEntity>> FindAllAsync(
            int page,
            int perPage,
            CancellationToken cancellationToken = default);
    }
}
