
namespace ProvaPub.Application.UseCases.Order.CanPurchase
{
    public class CanPurchaseHandler : ICanPurchaseHandler
    {
        public Task<bool> Handle(CanPurchaseRequest request, CancellationToken cancellationToken)
        {
            //O valor da compra deve ser maior que zero
            //o cliente deve estar registrar para realizar a compra
            //o cliente pode comprar apenas uma vez por mês
            //A primeira compra deve ter valor máximo de 100 reais
            //O cliente pode comprar apenas em horário comercial

            throw new NotImplementedException();
        }
    }
}
