using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Subcategory.List
{
    public sealed record GetSubcategoriesQuery() : IQuery<Result<List<CodeBookDto>>>;
}
