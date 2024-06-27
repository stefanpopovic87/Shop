using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Order.Get
{
    public record GetOrderQuery : IRequest<Result<OrderDto>>;
}
