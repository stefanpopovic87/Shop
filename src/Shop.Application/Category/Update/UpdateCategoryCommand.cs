using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Category.Update
{
    public sealed record UpdateCategoryCommand(int Id, string Name) : ICommand<Result<string>>;
}
