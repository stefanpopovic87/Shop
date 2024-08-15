using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Sizes.Delete
{
    public sealed record DeleteSizeCommand(int Id) : ICommand<Result<string>>;
}
