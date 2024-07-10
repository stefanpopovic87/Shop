using MediatR;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Order.Delete
{
    internal sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<string>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(
            IOrderRepository repository, 
            IUnitOfWork unitOfWork)
        {
            _orderRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(cancellationToken);

            if (order == null) 
            {
                return Result<string>.Failure(OrderErrorMessages.NotFound);
            }

            order.RemoveItem(request.ProductId, request.SizeId, request.Quantity);           


            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(OrderErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
