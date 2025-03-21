﻿using ProvaPub.Application.Facades;
using ProvaPub.Application.UseCases.Order.Commons;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Application.UseCases.Order.PayOrder
{
    public class PayOrderHandler(
        ICustomerRepository customerRepository,
        IPaymentFacade paymentFacade,
        IOrderRepository orderRepository,
        IUnitOfWork unitOfWork) : IPayOrderHandler
    {
        public async Task<OrderResponse> Handle(PayOrderRequest request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.FindAsync(request.CustomerId, cancellationToken);

            await paymentFacade.Process(request.Amount, request.PaymentMethod);

            var order = new OrderEntity(customerId: customer.Id, amount: request.Amount);
            await orderRepository.InsertAsync(order, cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            return OrderResponse.FromEntity(order, customer);
        }
    }
}
