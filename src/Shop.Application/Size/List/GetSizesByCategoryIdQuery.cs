using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Size.List
{
    public sealed record GetSizesByCategoryIdQuery(int categoryId) : IQuery<Result<List<CodeBookDto>>>;
}
