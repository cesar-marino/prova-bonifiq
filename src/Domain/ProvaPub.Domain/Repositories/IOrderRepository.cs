using ProvaPub.Domain.Entities;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Repositories
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        Task<IReadOnlyList<OrderEntity>> FindAllByCustomerIdAsync(
            Guid customerId,
            CancellationToken cancellationToken = default);
    }
}
