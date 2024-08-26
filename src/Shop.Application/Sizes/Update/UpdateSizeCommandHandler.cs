using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Sizes.Update
{
    internal sealed class UpdateSizeCommandHandler : ICommandHandler<UpdateSizeCommand, Result<string>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateSizeCommand> _validator;


        public UpdateSizeCommandHandler(
            ISizeRepository sizeRepository,
            IProductUnitOfWork unitOfWork,
            IValidator<UpdateSizeCommand> validator)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var size = await _sizeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (size is null)
            {
                return Result<string>.Failure(SizeErrorMessages.NotFound);
            }

            size.Update(request.Name, request.CategoryId);

            _sizeRepository.Update(size);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(SizeErrorMessages.Update);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
