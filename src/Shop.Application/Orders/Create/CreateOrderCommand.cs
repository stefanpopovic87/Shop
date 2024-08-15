using MediatR;
using Shop.Common;

namespace Shop.Application.Orders.Create
{
    public record CreateOrderCommand(int ProductId, int SizeId, int Quantity) : IRequest<Result<int>>;
}
