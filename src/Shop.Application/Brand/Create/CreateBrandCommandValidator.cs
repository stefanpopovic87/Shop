﻿using FluentValidation;
using Shop.Domain.Interfaces;

namespace Shop.Application.Brand.Create
{
    public sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private const int MaxNameLength = 100;

        public CreateBrandCommandValidator(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(BrandErrorMessages.NameIsRequired.Code)
                .WithMessage(BrandErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithErrorCode(BrandErrorMessages.NameTooLong(MaxNameLength).Code)
                .WithMessage(BrandErrorMessages.NameTooLong(MaxNameLength).Description);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellationToken) => !await brandRepository.UniqueNameAsync(name, cancellationToken))
                .WithErrorCode(BrandErrorMessages.NotUnique.Code)
                .WithMessage(BrandErrorMessages.NotUnique.Description);
        }
    }
}
