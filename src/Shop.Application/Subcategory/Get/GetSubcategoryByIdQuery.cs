using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Subcategory.Get
{
    public sealed record GetSubcategoryByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
