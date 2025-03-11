using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Domain.Entities
{
    public class ProductEntity : EntityBase
    {
        public string Name { get; }

        public ProductEntity(string name)
        {
            Name = name;
        }

        public ProductEntity(Guid productId, string name) : base(productId)
        {
            Name = name;
        }
    }
}
