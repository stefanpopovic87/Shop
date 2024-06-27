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
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product is null) 
            {
                return Result<int>.Failure(ProductErrorMessages.ProductNotFound(request.ProductId));

            }

            var size = await _sizeRepository.GetByIdAsync(request.SizeId);

            if (size is null)
            {
                return Result<int>.Failure(SizeErrorMessages.SizeNotFound(request.SizeId));
            }

            var productSize = await _productSizeRepository.GetByUniqueIdAsync(request.ProductId, request.SizeId);

            if (productSize is null)                 
            {
                return Result<int>.Failure(ProductSizeErrorMessages.ProductSizeNotFound);

            }

            if (productSize.QuantityInStock < request.Quantity)
            {
                return Result<int>.Failure(OrderErrorMessages.CreationQuantityError);
            }

            productSize.DecreaseQuantity(request.Quantity);

            var order = await _orderRepository.GetAsync();

            if (order is null) 
            {
                var status = await _orderStatusRepository.GetByIdAsync((int)OrderStatusEnum.Pending);

                if (status is null)
                {
                    return Result<int>.Failure(OrderStatusErrorMessages.OrderStatusNotFound((int)OrderStatusEnum.Pending));
                }

                order = new Domain.Entities.Order.Order(1); // TODO change to cuurentUserId
                order.SetOrderStatus(status);
                _orderRepository.Add(order);
            }

            order.AddItem(product, size, request.Quantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(OrderErrorMessages.CreationError);
            }

            return Result<int>.Success(order.Id);
        }
    }
}
