using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Category.Get
{
    public sealed record GetCategoryByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
