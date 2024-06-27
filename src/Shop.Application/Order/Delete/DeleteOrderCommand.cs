using MediatR;
using Shop.Common;
namespace Shop.Application.Order.Delete
{
    public record DeleteOrderCommand(int ProductId, int SizeId, int Quantity) : IRequest<Result<string>>;
}
