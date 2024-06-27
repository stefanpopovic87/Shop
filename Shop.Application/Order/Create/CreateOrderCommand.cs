using MediatR;
using Shop.Common;

namespace Shop.Application.Order.Create
{
    public record CreateOrderCommand(int ProductId, int SizeId, int Quantity) : IRequest<Result<int>>;
}
