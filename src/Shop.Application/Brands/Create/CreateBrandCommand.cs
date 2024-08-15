using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Brands.Create
{    public sealed record CreateBrandCommand(string Name) : ICommand<Result<int>>;
}
