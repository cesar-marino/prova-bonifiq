using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Repositories
{
    public class ProductRepository(ProvaPubContext context) : IProductRepository
    {
        public async Task<IReadOnlyList<ProductEntity>> FindAllAsync(int page, int perPage, CancellationToken cancellationToken = default)
        {
            try
            {
                var models = await context.Products
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

        public async Task<ProductEntity> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var model = await context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == id, cancellationToken)
                    ?? throw new NotFoundException("Product");

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

        public async Task InsertAsync(ProductEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ProductModel.FromEntity(entity);
                await context.Products.AddAsync(model, cancellationToken);
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
                var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == id, cancellationToken)
                    ?? throw new NotFoundException("Product");

                context.Products.Remove(product);
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

        public async Task UpdateAsync(ProductEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                var product = await context.Products.FirstOrDefaultAsync(x => x.ProductId == entity.Id, cancellationToken)
                    ?? throw new NotFoundException("Product");

                context.Entry(product).CurrentValues.SetValues(entity);
                context.Products.Entry(product).State = EntityState.Modified;
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
