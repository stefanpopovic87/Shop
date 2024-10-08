using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;
using Shop.Common;
using Shop.Domain.Entities.Orders;

namespace Shop.Application.OrderStatuses.Create
{
    internal sealed class CreateOrderStatusCommandHandler : ICommandHandler<CreateOrderStatusCommand, Result<int>>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderUnitOfWork _unitOfWork;
        private readonly IValidator<CreateOrderStatusCommand> _validator;

        public CreateOrderStatusCommandHandler(
            IOrderStatusRepository orderStatusRepository,
            IOrderUnitOfWork unitOfWork, 
            IValidator<CreateOrderStatusCommand> validator)
        {
            _orderStatusRepository = orderStatusRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var orderStatus = OrderStatus.Create(request.Name);

            _orderStatusRepository.Add(orderStatus);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(OrderStatusErrorMessages.Creation);
            }

            return Result<int>.Success(orderStatus.Id);
        }
    }
}
