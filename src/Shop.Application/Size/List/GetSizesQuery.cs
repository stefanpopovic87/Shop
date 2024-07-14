using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Size.List
{
    public sealed record GetSizesQuery() : IQuery<Result<List<CodeBookDto>>>;
}
