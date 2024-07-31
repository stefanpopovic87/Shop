using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using DomainEntities = Shop.Domain.Entities;

namespace Shop.Application.Size.Create
{
    internal sealed class CreateSizeCommandHandler : ICommandHandler<CreateSizeCommand, Result<int>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateSizeCommand> _validator;

        public CreateSizeCommandHandler(
            ISizeRepository sizeRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateSizeCommand> validator)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var size = new DomainEntities.Size(request.Name, request.CategoryId);

            _sizeRepository.Add(size);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(SizeErrorMessages.Creation);
            }

            return Result<int>.Success(size.Id);
        }
    }
}
