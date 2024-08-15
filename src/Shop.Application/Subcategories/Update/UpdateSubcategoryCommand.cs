using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Subcategories.Update
{
    public sealed record UpdateSubcategoryCommand(int Id, string Name, int CategoryId) : ICommand<Result<string>>;
}
