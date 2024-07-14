using FluentValidation;
using Shop.Domain.Interfaces;

namespace Shop.Application.Category.Create
{
    public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(CategoryErrorMessages.NameIsRequired.Code)
                .WithMessage(CategoryErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(CategoryErrorMessages.MaxNameLength)
                .WithErrorCode(CategoryErrorMessages.NameTooLong.Code)
                .WithMessage(CategoryErrorMessages.NameTooLong.Description);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellationToken) => !await categoryRepository.UniqueNameAsync(name, cancellationToken))
                .WithErrorCode(CategoryErrorMessages.NameNotUnique.Code)
                .WithMessage(CategoryErrorMessages.NameNotUnique.Description);
        }
    }
}
