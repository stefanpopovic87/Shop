﻿using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Categories.Update
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
                .WithErrorCode(CategoryErrorMessages.NameNotUnique.Code)
                .WithMessage(CategoryErrorMessages.NameNotUnique.Description);
        }
    }
}
