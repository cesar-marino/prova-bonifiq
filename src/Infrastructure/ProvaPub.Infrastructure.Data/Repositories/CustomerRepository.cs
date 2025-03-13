using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Repositories
{
    public class CustomerRepository(ProvaPubContext context) : ICustomerRepository
    {
        public async Task<IReadOnlyList<CustomerEntity>> FindAllAsync(
            int page,
            int perPage,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var models = await context.Customers
                    .AsNoTracking()
                    .Skip((page - 1) * perPage)
                    .Take(perPage)
                    .ToListAsync(cancellationToken);

                return [.. models.Select(x => x.ToEntity())];
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<CustomerEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var model = await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.CustomerId == id, cancellationToken)
                    ?? throw new NotFoundException("Customer");

                return model.ToEntity();
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
                var model = CustomerModel.FromEntity(entity);
                await context.Customers.AddAsync(model, cancellationToken);
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
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == id, cancellationToken)
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
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.CustomerId == entity.Id, cancellationToken)
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
