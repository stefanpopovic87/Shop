using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Subcategories.List
{
    public sealed record GetSubcategoriesByCategoryIdQuery(int categoryId) : IQuery<Result<List<CodeBookDto>>>;

}
