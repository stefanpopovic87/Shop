using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Subcategories.Update
{
    internal sealed class UpdateSubcategoryCommandHandler : ICommandHandler<UpdateSubcategoryCommand, Result<string>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateSubcategoryCommand> _validator;

        public UpdateSubcategoryCommandHandler(
            ISubcategoryRepository subcategoryRepository,
            IUnitOfWork unitOfWork,
            IValidator<UpdateSubcategoryCommand> validator)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var subcategory = await _subcategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (subcategory == null)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.NotFound);
            }

            subcategory.Update(request.Name, request.CategoryId);

            _subcategoryRepository.Update(subcategory);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.Update);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
