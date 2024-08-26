using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Create
{
    internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, Result<int>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<CreateCategoryCommand> _validator;

        public CreateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IProductUnitOfWork unitOfWork,
            IValidator<CreateCategoryCommand> validator)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var category = new Category(request.Name);

            _categoryRepository.Add(category);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(CategoryErrorMessages.Creation);
            }

            return Result<int>.Success(category.Id);
        }
    }
}
