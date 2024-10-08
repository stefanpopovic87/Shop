﻿using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Genders.Update
{
    public sealed class UpdateGenderCommandValidator : AbstractValidator<UpdateGenderCommand>
    {
        private readonly IGenderRepository _genderRepository;

        public UpdateGenderCommandValidator(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(GenderErrorMessages.NameIsRequired.Code)
                .WithMessage(GenderErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(GenderErrorMessages.MaxNameLength)
                .WithErrorCode(GenderErrorMessages.NameTooLong.Code)
                .WithMessage(GenderErrorMessages.NameTooLong.Description);

            RuleFor(x => x.Name)
                .MustAsync(async (name, cancellationToken) => !await genderRepository.UniqueNameAsync(name, cancellationToken))
                .WithErrorCode(GenderErrorMessages.NameNotUnique.Code)
                .WithMessage(GenderErrorMessages.NameNotUnique.Description);
        }
    }
}
