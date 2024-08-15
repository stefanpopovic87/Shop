using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Subcategories.List
{
    public sealed record GetSubcategoriesQuery() : IQuery<Result<List<CodeBookDto>>>;
}
