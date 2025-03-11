namespace ProvaPub.Application.UseCases.Product.Commons
{
    public class ProductResponse(
        Guid productId,
        string name)
    {
        public Guid ProductId { get; } = productId;
        public string Name { get; } = name;
    }
}
