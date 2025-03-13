﻿using ProvaPub.Application.Facades;
using ProvaPub.Application.UseCases.Order.Commons;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.Order.PayOrder
{
    public class PayOrderHandler(
        IPaymentFacade paymentFacade,
        IOrderRepository orderRepository) : IPayOrderHandler
    {
        public async Task<OrderResponse> Handle(PayOrderRequest request, CancellationToken cancellationToken)
        {
            await paymentFacade.Process(request.Amount, request.PaymentMethod);

            var order = new OrderEntity(value: request.Amount);
            await orderRepository.InsertAsync(order, cancellationToken);


            throw new NotImplementedException();
        }
    }
}
