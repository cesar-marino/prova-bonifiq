using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infrastructure.Data.Contexts;

namespace ProvaPub.Infrastructure.Data.Repositories
{
    public class RandomNumberRepository(ProvaPubContext context) : IRandomNumberRepository
    {
        public async Task<bool> CheckNumberAsync(int number, CancellationToken cancellationToken = default)
        {
            try
            {
                var randomNumber = await context.RandomNumbers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Number == number, cancellationToken);

                return randomNumber != null;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<IReadOnlyList<RandomNumberEntity>> FindAll(CancellationToken cancellationToken = default)
        {
            try
            {
                var randomNumbers = await context.RandomNumbers
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                return randomNumbers;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<RandomNumberEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var randomNumber = await context.RandomNumbers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                return randomNumber ?? throw new NotFoundException("RandomNumber");
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task InsertAsync(RandomNumberEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await context.RandomNumbers.AddAsync(entity, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var randomNumber = await context.RandomNumbers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new NotFoundException("RandomNumber");

                context.RandomNumbers.Remove(randomNumber);
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task UpdateAsync(RandomNumberEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var randomNumber = await context.RandomNumbers.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken)
                    ?? throw new NotFoundException("RandomNumber");

                context.Entry(randomNumber).CurrentValues.SetValues(entity);
                context.RandomNumbers.Entry(randomNumber).State = EntityState.Modified;
            }
            catch (DomainException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }
    }
}
