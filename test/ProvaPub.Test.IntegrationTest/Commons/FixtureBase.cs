using Microsoft.EntityFrameworkCore;
using ProvaPub.Infrastructure.Data.Contexts;

namespace ProvaPub.Test.IntegrationTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;

        public ProvaPubContext MakeContext() => new(
            new DbContextOptionsBuilder<ProvaPubContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
    }
}
