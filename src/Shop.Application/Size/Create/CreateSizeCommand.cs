using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Size.Create
{
    public sealed record CreateSizeCommand(string Name, int CategoryId) : ICommand<Result<int>>;
}
