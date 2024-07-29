using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Order.Get
{
    internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Result<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(cancellationToken);

            if (order is null) 
            {
                return Result<OrderDto>.Failure(OrderErrorMessages.NotFound);

            }            

            return Result<OrderDto>.Success(null); // TODO: Create logic for get order
        }
    }
}
