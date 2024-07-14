using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Gender.Get
{
    public sealed record GetGenderByIdQuery(int Id) : IQuery<Result<CodeBookDto>>;
}
