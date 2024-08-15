using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Brands.Update
{
    public sealed record UpdateBrandCommand(int Id, string Name) : ICommand<Result<string>>;
}
