namespace ProvaPub.Application.Facades
{
    public interface IPaymentFacade
    {
        Task Process(decimal amount, string method);
    }
}
