using MediatR;
using Shop.Common;

namespace Shop.Application.Order.Get
{
    public record GetOrderQuery : IRequest<Result<GetOrderResponse>>;
}
