using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.Update
{
    public sealed class UpdateProductCommandValidation : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly ISizeRepository _sizeRepository;


        public UpdateProductCommandValidation(
            IProductRepository productRepository,
            IBrandRepository brandRepository,
            ISubcategoryRepository subcategoryRepository,
            IGenderRepository genderRepository,
            ISizeRepository sizeRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _subcategoryRepository = subcategoryRepository;
            _genderRepository = genderRepository;
            _sizeRepository = sizeRepository;

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithErrorCode(ProductErrorMessages.NameIsRequired.Code)
               .WithMessage(ProductErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(ProductErrorMessages.MaxNameLength)
                .WithErrorCode(ProductErrorMessages.NameTooLong.Code)
                .WithMessage(ProductErrorMessages.NameTooLong.Description);

            RuleFor(x => x.Description)
               .NotEmpty()
               .WithErrorCode(ProductErrorMessages.DescriptionIsRequired.Code)
               .WithMessage(ProductErrorMessages.DescriptionIsRequired.Description);

            RuleFor(x => x.Description)
                .MaximumLength(ProductErrorMessages.MaxDescriptionLength)
                .WithErrorCode(ProductErrorMessages.DescriptionTooLong.Code)
                .WithMessage(ProductErrorMessages.DescriptionTooLong.Description);

            RuleFor(x => x.Code)
               .NotEmpty()
               .WithErrorCode(ProductErrorMessages.CodeIsRequired.Code)
               .WithMessage(ProductErrorMessages.CodeIsRequired.Description);

            RuleFor(x => x.Code)
                .MaximumLength(ProductErrorMessages.MaxCodeLength)
                .WithErrorCode(ProductErrorMessages.CodeTooLong.Code)
                .WithMessage(ProductErrorMessages.CodeTooLong.Description);

            RuleFor(x => x.Price)
                .GreaterThan(ProductErrorMessages.MinPriceValue)
                .WithErrorCode(ProductErrorMessages.PriceMinValue.Code)
                .WithMessage(ProductErrorMessages.PriceMinValue.Description);

            RuleFor(x => x.Price)
                .LessThan(ProductErrorMessages.MaxPriceValue)
                .WithErrorCode(ProductErrorMessages.PriceMaxValue.Code)
                .WithMessage(ProductErrorMessages.PriceMaxValue.Description);

            RuleFor(x => x.BrandId)
               .GreaterThan(ProductErrorMessages.MinBrandValue)
               .WithErrorCode(ProductErrorMessages.PriceMinValue.Code)
               .WithMessage(ProductErrorMessages.PriceMinValue.Description);

            RuleFor(x => x.BrandId)
                .MustAsync(async (brandId, cancellationToken) => await _brandRepository.ExistsAsync(brandId, cancellationToken))
                .WithErrorCode(ProductErrorMessages.BrandNotExist.Code)
                .WithMessage(ProductErrorMessages.BrandNotExist.Description);

            RuleFor(x => x.SubcategoryId)
               .GreaterThan(ProductErrorMessages.MinSubcategoryValue)
               .WithErrorCode(ProductErrorMessages.SubcategoryMinValue.Code)
               .WithMessage(ProductErrorMessages.SubcategoryMinValue.Description);

            RuleFor(x => x.SubcategoryId)
                .MustAsync(async (subcategoryId, cancellationToken) => await _subcategoryRepository.ExistsAsync(subcategoryId, cancellationToken))
                .WithErrorCode(ProductErrorMessages.SubcategoryNotExist.Code)
                .WithMessage(ProductErrorMessages.SubcategoryNotExist.Description);

            RuleFor(x => x.GenderId)
               .GreaterThan(ProductErrorMessages.MinGenderValue)
               .WithErrorCode(ProductErrorMessages.GenderMinValue.Code)
               .WithMessage(ProductErrorMessages.GenderMinValue.Description);

            RuleFor(x => x.GenderId)
                .MustAsync(async (genderId, cancellationToken) => await _genderRepository.ExistsAsync(genderId, cancellationToken))
                .WithErrorCode(ProductErrorMessages.GenderNotExist.Code)
                .WithMessage(ProductErrorMessages.GenderNotExist.Description);

            RuleFor(x => x.ProductSizeQuantities)
                .NotNull()
                .WithErrorCode(ProductErrorMessages.SizeQuantitiesCannotBeNull.Code)
                .WithMessage(ProductErrorMessages.SizeQuantitiesCannotBeNull.Description)
                .Must(x => x.Count > 0)
                .WithErrorCode(ProductErrorMessages.SizeQuantitiesMustContainItems.Code)
                .WithMessage(ProductErrorMessages.SizeQuantitiesMustContainItems.Description);

            RuleForEach(x => x.ProductSizeQuantities).ChildRules(sizeQuantity =>
            {
                sizeQuantity.RuleFor(x => x.Quantity)
                    .GreaterThan(ProductErrorMessages.MinQuantityValue)
                    .WithErrorCode(ProductErrorMessages.QuantityMinValue.Code)
                    .WithMessage(ProductErrorMessages.QuantityMinValue.Description);

                sizeQuantity.RuleFor(x => x.Quantity)
                    .LessThan(ProductErrorMessages.MaxQuantityValue)
                    .WithErrorCode(ProductErrorMessages.QuantityMaxValue.Code)
                    .WithMessage(ProductErrorMessages.QuantityMaxValue.Description);

                sizeQuantity.RuleFor(x => x.SizeId)
                    .MustAsync(async (sizeId, cancellationToken) => await _sizeRepository.ExistsAsync(sizeId, cancellationToken))
                    .WithErrorCode(ProductErrorMessages.SizeNotExist.Code)
                    .WithMessage(ProductErrorMessages.SizeNotExist.Description);
            });
        }

    }
}
