using ProvaPub.Domain.Entities;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Repositories
{
    public interface IRandomNumberRepository : IRepository<RandomNumberEntity>
    {
        Task<bool> CheckNumberAsync(int number, CancellationToken cancellationToken = default);
    }
}
