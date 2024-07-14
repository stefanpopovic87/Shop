using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Category.Update
{
    public sealed record ActivateCategoryCommand(int Id) : ICommand<Result<string>>;
}
