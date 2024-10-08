using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Delete
{
    public sealed record DeleteOrderStatusCommand(int Id) : ICommand<Result<string>>;
}
