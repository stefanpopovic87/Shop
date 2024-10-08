using Shop.Application.Abstractions;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Delete
{
    internal sealed class DeleteOrderStatusCommandHandler : ICommandHandler<DeleteOrderStatusCommand, Result<string>>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderUnitOfWork _unitOfWork;

        public DeleteOrderStatusCommandHandler(
            IOrderStatusRepository orderStatusRepository,
            IOrderUnitOfWork unitOfWork)
        {
            _orderStatusRepository = orderStatusRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var orderStatus = await _orderStatusRepository.GetByIdAsync(request.Id, cancellationToken);

            if (orderStatus is null)
            {
                return Result<string>.Failure(OrderStatusErrorMessages.NotFound);
            }

            _orderStatusRepository.Delete(orderStatus);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(OrderStatusErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
