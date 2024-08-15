using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Categories.Update
{
    public sealed record ActivateCategoryCommand(int Id) : ICommand<Result<string>>;
}
