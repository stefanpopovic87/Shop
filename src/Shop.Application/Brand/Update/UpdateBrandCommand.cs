using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Brand.Update
{
    public sealed record UpdateBrandCommand(int Id, string Name) : ICommand<Result<string>>;
}
