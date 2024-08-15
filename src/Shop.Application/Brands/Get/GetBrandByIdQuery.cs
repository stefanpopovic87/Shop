using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Brands.Get
{
    public sealed record GetBrandByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
