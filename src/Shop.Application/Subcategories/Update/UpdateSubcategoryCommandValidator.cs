﻿using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Subcategories.Update
{
    public sealed class UpdateSubcategoryCommandValidator : AbstractValidator<UpdateSubcategoryCommand>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateSubcategoryCommandValidator(ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(SubcategoryErrorMessages.NameIsRequired.Code)
                .WithMessage(SubcategoryErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(SubcategoryErrorMessages.MaxNameLength)
                .WithErrorCode(SubcategoryErrorMessages.NameTooLong.Code)
                .WithMessage(SubcategoryErrorMessages.NameTooLong.Description);

            RuleFor(x => x.CategoryId)
                .MustAsync(async (categoryId, cancellationToken) => await categoryRepository.ExistsAsync(categoryId, cancellationToken))
                .WithErrorCode(SubcategoryErrorMessages.CategoryNotExist.Code)
                .WithMessage(SubcategoryErrorMessages.CategoryNotExist.Description);

            RuleFor(x => x)
                .MustAsync(async (command, cancellationToken) => !await _subcategoryRepository.UniqueNameInCategoryAsync(command.Name, command.CategoryId, cancellationToken))
                .WithErrorCode(SubcategoryErrorMessages.NameNotUniqueInCategory.Code)
                .WithMessage(SubcategoryErrorMessages.NameNotUniqueInCategory.Description);
        }
    }
}
