﻿using FluentValidation;
using Shop.Application.Brands.Update;
using Shop.Application.Interfaces;

namespace Shop.Application.Brands.Create
{
    public sealed class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;

        public UpdateBrandCommandValidator(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(BrandErrorMessages.NameIsRequired.Code)
                .WithMessage(BrandErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(BrandErrorMessages.MaxNameLength)
                .WithErrorCode(BrandErrorMessages.NameTooLong.Code)
                .WithMessage(BrandErrorMessages.NameTooLong.Description);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellationToken) => !await brandRepository.UniqueNameAsync(name, cancellationToken))
                .WithErrorCode(BrandErrorMessages.NameNotUnique.Code)
                .WithMessage(BrandErrorMessages.NameNotUnique.Description);
        }
    }
}
