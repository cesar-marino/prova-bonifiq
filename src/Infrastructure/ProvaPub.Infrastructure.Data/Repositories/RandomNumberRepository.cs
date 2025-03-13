using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Models;

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

        public async Task<RandomNumberEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var randomNumber = await context.RandomNumbers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.RandomNumberId == id, cancellationToken);

                return randomNumber?.ToEntity() ?? throw new NotFoundException("RandomNumber");
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
                var model = RandomNumberModel.FromEntity(entity);
                await context.RandomNumbers.AddAsync(model, cancellationToken);
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
                var randomNumber = await context.RandomNumbers.FirstOrDefaultAsync(x => x.RandomNumberId == id, cancellationToken)
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
                var randomNumber = await context.RandomNumbers.FirstOrDefaultAsync(x => x.RandomNumberId == entity.Id, cancellationToken)
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
