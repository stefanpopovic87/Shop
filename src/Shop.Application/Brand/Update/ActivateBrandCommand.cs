using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Brand.Update
{
    public sealed record ActivateBrandCommand(int Id) : ICommand<Result<string>>;

}
