using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Size.Get
{
    public sealed record GetSizeByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
