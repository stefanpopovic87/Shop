using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Sizes.Get
{
    public sealed record GetSizeByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
