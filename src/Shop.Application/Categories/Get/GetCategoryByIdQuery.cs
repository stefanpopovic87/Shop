using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Categories.Get
{
    public sealed record GetCategoryByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
