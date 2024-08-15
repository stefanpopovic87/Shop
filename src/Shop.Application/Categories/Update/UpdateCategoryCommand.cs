using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Categories.Update
{
    public sealed record UpdateCategoryCommand(int Id, string Name) : ICommand<Result<string>>;
}
