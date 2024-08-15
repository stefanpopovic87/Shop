using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Subcategories.Create
{
    public sealed record CreateSubcategoryCommand(string Name, int CategoryId) : ICommand<Result<int>>;
}
