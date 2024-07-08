using MediatR;
using Shop.Common;
using Shop.Domain.Entities.Enums;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Order.Create
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            ISizeRepository sizeRepository,
            IOrderStatusRepository orderStatusRepository,
            IProductSizeRepository productSizeRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _orderStatusRepository = orderStatusRepository;
            _productSizeRepository = productSizeRepository;
        }

        public async Task<Result<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId,cancellationToken);

            if (product is null) 
            {
                return Result<int>.Failure(ProductErrorMessages.NotFound);

            }

            var size = await _sizeRepository.GetByIdAsync(request.SizeId, cancellationToken);

            if (size is null)
            {
                return Result<int>.Failure(SizeErrorMessages.NotFound);
            }

            var productSize = await _productSizeRepository.GetByUniqueIdAsync(request.ProductId, request.SizeId,cancellationToken);

            if (productSize is null)                 
            {
                return Result<int>.Failure(ProductSizeErrorMessages.NotFound);

            }

            if (productSize.QuantityInStock < request.Quantity)
            {
                return Result<int>.Failure(OrderErrorMessages.CreationQuantity);
            }

            productSize.DecreaseQuantity(request.Quantity);

            var order = await _orderRepository.GetAsync(cancellationToken);

            if (order is null) 
            {
                var status = await _orderStatusRepository.GetByIdAsync((int)OrderStatusEnum.Pending, cancellationToken);

                if (status is null)
                {
                    return Result<int>.Failure(OrderStatusErrorMessages.NotFound);
                }

                order = new Domain.Entities.Order.Order(1); // TODO - chage to current user ID
                order.SetOrderStatus(status);
                _orderRepository.Add(order);
            }

            order.AddItem(product, size, request.Quantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(OrderErrorMessages.Creation);
            }

            return Result<int>.Success(order.Id);
        }
    }
}
