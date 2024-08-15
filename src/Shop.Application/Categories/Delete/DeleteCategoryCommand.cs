using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Categories.Delete
{
    public sealed record DeleteCategoryCommand(int Id) : ICommand<Result<string>>;
}
