using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Subcategory.Update
{
    public sealed record ActivateSubcategoryCommand(int Id) : ICommand<Result<string>>;
}
