using MediatR;
using Shop.Common;
using Shop.Domain.Entities.Enums;
using Shop.Domain.ErrorMessages;
using Shop.Application.Interfaces;

namespace Shop.Application.Orders.Create
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<int>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IProductRepository productRepository,
            ISizeRepository sizeRepository,
            IOrderStatusRepository orderStatusRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _orderStatusRepository = orderStatusRepository;
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

            var order = await _orderRepository.GetAsync(cancellationToken);

            if (order is null) 
            {
                var status = await _orderStatusRepository.GetByIdAsync((int)OrderStatusEnum.Pending, cancellationToken);

                if (status is null)
                {
                    return Result<int>.Failure(OrderStatusErrorMessages.NotFound);
                }

                order = new Domain.Entities.Orders.Order(1); // TODO - change to current user ID
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
