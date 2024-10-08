using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Application.Interfaces;
using Shop.Common;

namespace Shop.Application.OrderStatuses.List
{
    internal sealed class GetOrderStatusesQueryHandler : IQueryHandler<GetOrderStatusesQuery, Result<List<CodeBookDto>>>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public GetOrderStatusesQueryHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetOrderStatusesQuery request, CancellationToken cancellationToken)
        {
            var orderStatuses = await _orderStatusRepository.GetAllAsync(cancellationToken);

            if (orderStatuses is null || orderStatuses.Count == 0)
            {
                return Result<List<CodeBookDto>>.Failure(OrderStatusErrorMessages.OrderStatusesNotFound);
            }

            var orderStatusesDto = orderStatuses.Select(x => new CodeBookDto
            (
                x.Id,
                x.Name
            )).ToList();

            return Result<List<CodeBookDto>>.Success(orderStatusesDto);
        }
    }
}
