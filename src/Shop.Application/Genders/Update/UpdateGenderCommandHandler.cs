using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Genders.Update
{
    internal sealed class UpdateGenderCommandHandler : ICommandHandler<UpdateGenderCommand, Result<string>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateGenderCommand> _validator;

        public UpdateGenderCommandHandler(
            IGenderRepository genderRepository,
            IUnitOfWork unitOfWork,
            IValidator<UpdateGenderCommand> validator)
        {
            _genderRepository = genderRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var gender = await _genderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (gender is null)
            {
                return Result<string>.Failure(GenderErrorMessages.NotFound);
            }

            gender.Update(request.Name);

            _genderRepository.Update(gender);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(GenderErrorMessages.Update);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
