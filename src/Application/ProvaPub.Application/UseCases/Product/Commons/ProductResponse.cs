using ProvaPub.Domain.Entities;

namespace ProvaPub.Application.UseCases.Product.Commons
{
    public class ProductResponse(
        Guid productId,
        string name)
    {
        public Guid ProductId { get; } = productId;
        public string Name { get; } = name;

        public static ProductResponse FromEntity(ProductEntity product) => new(
            productId: product.Id,
            name: product.Name);
    }
}
