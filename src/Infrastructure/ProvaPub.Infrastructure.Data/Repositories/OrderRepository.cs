using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Repositories
{
    public class OrderRepository(ProvaPubContext context) : IOrderRepository
    {
        public async Task<IReadOnlyList<OrderEntity>> FindAllByCustomerIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            try
            {
                var models = await context.Orders
                    .AsNoTracking()
                    .Where(x => x.CustomerId == customerId)
                    .ToListAsync(cancellationToken);

                return (IReadOnlyList<OrderEntity>)models.Select(x => x.ToEntity());
            }
            catch (Exception ex)
            {
                throw new UnexpectedException(innerException: ex);
            }
        }

        public async Task<OrderEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var model = await context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.OrderId == id, cancellationToken)
                    ?? throw new NotFoundException("Order");

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

        public async Task InsertAsync(OrderEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var model = OrderModel.FromEntity(entity);
                await context.Orders.AddAsync(model, cancellationToken);
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
                var order = await context.Orders.FirstOrDefaultAsync(x => x.OrderId == id, cancellationToken)
                    ?? throw new NotFoundException("Order");

                context.Orders.Remove(order);
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

        public async Task UpdateAsync(OrderEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var order = await context.Orders.FirstOrDefaultAsync(x => x.OrderId == entity.Id, cancellationToken)
                    ?? throw new NotFoundException("Order");

                context.Entry(order).CurrentValues.SetValues(entity);
                context.Orders.Entry(order).State = EntityState.Modified;
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
