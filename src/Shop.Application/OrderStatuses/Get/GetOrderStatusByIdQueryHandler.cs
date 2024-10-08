using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Application.Interfaces;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Get
{
    internal sealed class GetOrderStatusByIdQueryHandler : IQueryHandler<GetOrderStatusByIdQuery, Result<CodeBookDto>>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public GetOrderStatusByIdQueryHandler(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<Result<CodeBookDto>> Handle(GetOrderStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var orderStatus = await _orderStatusRepository.GetByIdAsync(request.id, cancellationToken);

            if (orderStatus == null) 
            {
                return Result<CodeBookDto>.Failure(OrderStatusErrorMessages.NotFound);
            }

            var orderStatusDto = new CodeBookDto(
                orderStatus.Id,
                orderStatus.Name
            );

            return Result<CodeBookDto>.Success(orderStatusDto);


        }
    }
}
