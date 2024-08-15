using MediatR;
using Shop.Common;

namespace Shop.Application.Orders.Get
{
    public record GetOrderQuery : IRequest<Result<GetOrderResponse>>;
}
