using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Size.Update
{
    public sealed record ActivateSizeCommand(int Id) : ICommand<Result<string>>;
}
