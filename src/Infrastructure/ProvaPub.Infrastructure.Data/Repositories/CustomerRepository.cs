using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infrastructure.Data.Contexts;

namespace ProvaPub.Infrastructure.Data.Repositories
{
    public class CustomerRepository(ProvaPubContext context) : ICustomerRepository
    {
        public Task<IReadOnlyList<CustomerEntity>> FindAllAsync(
            int page,
            int perPage,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new NotFoundException("Customer");
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

        public async Task InsertAsync(CustomerEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                await context.Customers.AddAsync(entity, cancellationToken);
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
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new NotFoundException("Customer");

                context.Customers.Remove(customer);
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

        public async Task UpdateAsync(CustomerEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == entity.Id, cancellationToken)
                    ?? throw new NotFoundException("Customer");

                context.Entry(customer).CurrentValues.SetValues(entity);
                context.Customers.Entry(customer).State = EntityState.Modified;
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
