using FluentValidation;
using Shop.Domain.Interfaces;

namespace Shop.Application.Category.Update
{
    public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(CategoryErrorMessages.NameIsRequired.Code)
                .WithMessage(CategoryErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithErrorCode(CategoryErrorMessages.NameTooLong.Code)
                .WithMessage(CategoryErrorMessages.NameTooLong.Description);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellationToken) => !await categoryRepository.UniqueNameAsync(name, cancellationToken))
                .WithErrorCode(CategoryErrorMessages.NotUnique.Code)
                .WithMessage(CategoryErrorMessages.NotUnique.Description);
        }
    }
}
