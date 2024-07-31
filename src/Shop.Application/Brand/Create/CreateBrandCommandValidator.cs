using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Brand.Create
{
    public sealed class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandCommandValidator(IBrandRepository brandRepository)
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
                .MustAsync(async (name, cancellationToken) => !await _brandRepository.UniqueNameAsync(name, cancellationToken))
                .WithErrorCode(BrandErrorMessages.NameNotUnique.Code)
                .WithMessage(BrandErrorMessages.NameNotUnique.Description);
        }
    }
}
