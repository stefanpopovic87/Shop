using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Create
{
    public sealed record CreateOrderStatusCommand(string Name) : ICommand<Result<int>>;
}
