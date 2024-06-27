using MediatR;
using Shop.Common;
using Shop.Domain.Entities.Enums;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Order.Delete
{
    internal sealed class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<string>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(
            IOrderRepository repository, 
            IUnitOfWork unitOfWork, 
            IProductSizeRepository productSizeRepository)
        {
            _orderRepository = repository;
            _unitOfWork = unitOfWork;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<Result<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync();

            if (order == null) 
            {
                return Result<string>.Failure(OrderErrorMessages.OrderNotFound);
            }

            order.RemoveItem(request.ProductId, request.SizeId, request.Quantity);

            var productSize = await _productSizeRepository.GetByUniqueIdAsync(request.ProductId, request.SizeId);

            if (productSize is null)
            {
                return Result<string>.Failure(ProductSizeErrorMessages.ProductSizeNotFound);

            }

            productSize.IncreaseQuantity(request.Quantity);            


            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(OrderErrorMessages.DeletionError);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
