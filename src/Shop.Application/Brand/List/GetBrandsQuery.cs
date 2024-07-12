using MediatR;
using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.Brand.List
{
    public sealed record GetBrandsQuery() : IQuery<Result<List<CodeBookDto>>>;
}
