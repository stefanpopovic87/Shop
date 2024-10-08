using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Update
{
    public sealed record UpdateOrderStatusCommand(int Id, string Name) : ICommand<Result<string>>;
}
