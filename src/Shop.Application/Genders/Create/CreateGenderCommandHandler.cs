using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Application.Interfaces.UnitOfWork;

namespace Shop.Application.Genders.Create
{
    internal sealed class CreateGenderCommandHandler : ICommandHandler<CreateGenderCommand, Result<int>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<CreateGenderCommand> _validator;

        public CreateGenderCommandHandler(
            IGenderRepository genderRepository,
            IProductUnitOfWork unitOfWork,
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
            var gender = Gender.Create(request.Name);

            _genderRepository.Add(gender);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(GenderErrorMessages.Creation);
            }

            return Result<int>.Success(gender.Id);
        }
    }
}
