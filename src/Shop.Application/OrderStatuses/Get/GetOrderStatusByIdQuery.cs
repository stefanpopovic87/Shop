using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Get
{
    public sealed record GetOrderStatusByIdQuery(int id) : IQuery<Result<CodeBookDto>>;
}
