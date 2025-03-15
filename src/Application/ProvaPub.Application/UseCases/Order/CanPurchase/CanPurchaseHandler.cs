
namespace ProvaPub.Application.UseCases.Order.CanPurchase
{
    public class CanPurchaseHandler : ICanPurchaseHandler
    {
        public Task<bool> Handle(CanPurchaseRequest request, CancellationToken cancellationToken)
        {
            //Recuperar o customer (se não existir lança NotFoundException - Atende a regra 2)
            //Cria uma Order (se o valor de amount for menor que 1 lança Exception - Deve ser atendida no construtor da classe order)

            //Recupera a lista de compras realizada pelo cliente


            //2. O cliente deve estar registrado para realizar a compra

            //1. O valor da compra deve ser maior que zero
            //3. O cliente pode comprar apenas uma vez por mês
            //4. A primeira compra deve ter valor máximo de 100 reais
            //5. O cliente pode comprar apenas em horário comercial

            throw new NotImplementedException();
        }
    }
}
