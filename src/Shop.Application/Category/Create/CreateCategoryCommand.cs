using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Category.Create
{
    public sealed record CreateCategoryCommand(string Name) : ICommand<Result<int>>;
}
