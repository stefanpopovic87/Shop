using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;
using Shop.Common;

namespace Shop.Application.OrderStatuses.Update
{
    internal sealed class UpdateOrderStatusCommandHandler : ICommandHandler<UpdateOrderStatusCommand, Result<string>>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateOrderStatusCommand> _validator;

        public UpdateOrderStatusCommandHandler(
            IOrderStatusRepository orderStatusRepository,
            IOrderUnitOfWork unitOfWork,
            IValidator<UpdateOrderStatusCommand> validator)
        {
            _orderStatusRepository = orderStatusRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var orderStatus = await _orderStatusRepository.GetByIdAsync(request.Id, cancellationToken);

            if (orderStatus == null) 
            {
                return Result<string>.Failure(OrderStatusErrorMessages.NotFound);
            }

            orderStatus.Update(request.Name);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(OrderStatusErrorMessages.Update);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
