using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Gender.List
{
    public sealed record GetGendersQuery() : IQuery<Result<List<CodeBookDto>>>;
}
