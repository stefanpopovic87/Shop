using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Sizes.Update
{
    public sealed record UpdateSizeCommand(int Id, string Name, int CategoryId) : ICommand<Result<string>>;
}
