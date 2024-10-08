using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;

namespace Shop.Application.OrderStatuses.List
{
    public sealed record GetOrderStatusesQuery() : IQuery<Result<List<CodeBookDto>>>;
}
