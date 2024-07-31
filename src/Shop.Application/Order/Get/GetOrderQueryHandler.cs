using MediatR;
using Shop.Common;
using Shop.Domain.ErrorMessages;
using Shop.Application.Interfaces;

namespace Shop.Application.Order.Get
{
    internal sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Result<GetOrderResponse>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Result<GetOrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(cancellationToken);

            if (order is null) 
            {
                return Result<GetOrderResponse>.Failure(OrderErrorMessages.NotFound);

            }            

            return Result<GetOrderResponse>.Success(null); // TODO: Create logic for get order
        }
    }
}
