using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Sizes.Update
{
    public sealed record ActivateSizeCommand(int Id) : ICommand<Result<string>>;
}
