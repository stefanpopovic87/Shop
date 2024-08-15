using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Categories.List
{
    public sealed record GetCategoriesQuery() : IQuery<Result<List<CodeBookDto>>>;
}
