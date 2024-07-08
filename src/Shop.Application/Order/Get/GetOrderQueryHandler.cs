using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
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

            var orderDto = new OrderDto(
                order.Id,
                order.ShippingAddressId,
                order.Items.Select(item => new OrderItemDto(
                    item.Id,
                    item.Quantity,
                    new ProductDto(
                        item.Product.Id, 
                        item.Product.Name, 
                        item.Product.Description, 
                        item.Product.Price, 
                        item.Product.PictureUrl),
                    new SizeDto(
                        item.Size.Id, 
                        item.Size.Name)
                )).ToList()
            );

            return Result<OrderDto>.Success(orderDto);
        }
    }
}
