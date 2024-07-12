using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Brand.Get
{
    public sealed record GetBrandByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
