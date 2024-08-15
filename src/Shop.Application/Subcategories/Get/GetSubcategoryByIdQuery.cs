using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Subcategories.Get
{
    public sealed record GetSubcategoryByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
