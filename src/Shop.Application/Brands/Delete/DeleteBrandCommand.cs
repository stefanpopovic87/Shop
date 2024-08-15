using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Brands.Delete
{
    public sealed record DeleteBrandCommand(int Id) : ICommand<Result<string>>;
}
