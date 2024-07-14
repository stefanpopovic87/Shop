using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Category;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Domain.Interfaces;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Subcategory.Create
{
    internal sealed class CreateSubcategoryCommandHandler : ICommandHandler<CreateSubcategoryCommand, Result<int>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateSubcategoryCommand> _validator;

        public CreateSubcategoryCommandHandler(
            ISubcategoryRepository subcategoryRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateSubcategoryCommand> validator,
            ICategoryRepository categoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<int>> Handle(CreateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var subcategory = new ProductEntities.Subcategory(request.Name, request.CategoryId);

            _subcategoryRepository.Add(subcategory);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(SubcategoryErrorMessages.Creation);
            }

            return Result<int>.Success(subcategory.Id);
        }
    }
}
