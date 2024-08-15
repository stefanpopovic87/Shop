using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Sizes.List
{
    public sealed record GetSizesByCategoryIdQuery(int categoryId) : IQuery<Result<List<CodeBookDto>>>;
}
