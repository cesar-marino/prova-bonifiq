using ProvaPub.Domain.Entities;

namespace ProvaPub.Infrastructure.Data.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; }
        public string Name { get; }

        public ProductModel(
            Guid productId,
            string name)
        {
            ProductId = productId;
            Name = name;
        }

        public static ProductModel FromEntity(ProductEntity product) => new(
            productId: product.Id,
            name: product.Name);

        public ProductEntity ToEntity() => new(
            productId: ProductId,
            name: Name);

#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
        protected ProductModel() { }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar como anulável.
    }
}