using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Brand.Create
{
    public sealed record CreateBrandCommand(string Name) : ICommand<Result<int>>;
}
