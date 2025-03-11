using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Infrastructure.Data.Contexts
{
    public class UnitOfWork(ProvaPubContext context) : IUnitOfWork
    {
        public async Task CommitAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);
    }
}
