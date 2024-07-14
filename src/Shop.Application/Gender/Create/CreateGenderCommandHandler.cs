using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Domain.Interfaces;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Gender.Create
{
    internal sealed class CreateGenderCommandHandler : ICommandHandler<CreateGenderCommand, Result<int>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateGenderCommand> _validator;

        public CreateGenderCommandHandler(
            IGenderRepository genderRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateGenderCommand> validator)
        {
            _genderRepository = genderRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateGenderCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var gender = new ProductEntities.Gender(request.Name);

            _genderRepository.Add(gender);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(GenderErrorMessages.Creation);
            }

            return Result<int>.Success(gender.Id);
        }
    }
}
