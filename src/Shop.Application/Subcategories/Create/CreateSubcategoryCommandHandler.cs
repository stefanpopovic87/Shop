using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;


namespace Shop.Application.Subcategories.Create
{
    internal sealed class CreateSubcategoryCommandHandler : ICommandHandler<CreateSubcategoryCommand, Result<int>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<CreateSubcategoryCommand> _validator;

        public CreateSubcategoryCommandHandler(
            ISubcategoryRepository subcategoryRepository,
            IProductUnitOfWork unitOfWork,
            IValidator<CreateSubcategoryCommand> validator)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;        
        }

        public async Task<Result<int>> Handle(CreateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var subcategory = Subcategory.Create(request.Name, request.CategoryId);

            _subcategoryRepository.Add(subcategory);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(SubcategoryErrorMessages.Creation);
            }

            return Result<int>.Success(subcategory.Id);
        }
    }
}
