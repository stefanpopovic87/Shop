﻿using FluentValidation;
using Shop.Application.Subcategories;
using Shop.Application.Interfaces;

namespace Shop.Application.Sizes.Create
{
    public sealed class CreateSizeCommandValidator : AbstractValidator<CreateSizeCommand>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateSizeCommandValidator(ISizeRepository sizeRepository, ICategoryRepository categoryRepository)
        {
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(SizeErrorMessages.NameIsRequired.Code)
                .WithMessage(SizeErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(SizeErrorMessages.MaxNameLength)
                .WithErrorCode(SizeErrorMessages.NameTooLong.Code)
                .WithMessage(SizeErrorMessages.NameTooLong.Description);

            RuleFor(x => x.CategoryId)
               .MustAsync(async (categoryId, cancellationToken) => await categoryRepository.ExistsAsync(categoryId, cancellationToken))
               .WithErrorCode(SizeErrorMessages.CategoryNotExists.Code)
               .WithMessage(SizeErrorMessages.CategoryNotExists.Description);

            RuleFor(x => x)
                .MustAsync(async (command, cancellationToken) => !await _sizeRepository.UniqueNameInCategoryAsync(command.Name, command.CategoryId, cancellationToken))
                .WithErrorCode(SizeErrorMessages.NameNotUniqueInCategory.Code)
                .WithMessage(SizeErrorMessages.NameNotUniqueInCategory.Description);           
        }
    }
}
