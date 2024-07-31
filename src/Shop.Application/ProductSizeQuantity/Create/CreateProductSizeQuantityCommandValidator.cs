using FluentValidation;
using Shop.Application.Interfaces;

namespace Shop.Application.ProductSizeQuantity.Create
{
    public sealed class CreateProductSizeQuantityCommandValidator : AbstractValidator<CreateProductSizeQuantityCommand>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;

        public CreateProductSizeQuantityCommandValidator(
            IProductSizeQuantityRepository productSizeQuantityRepository, 
            IProductRepository productRepository, 
            ISizeRepository sizeRepository)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;

            RuleFor(x => x.QuantityInStock)
                .GreaterThan(ProductSizeQuantityErrorMessages.QuantityGreaterThan)
                .WithErrorCode(ProductSizeQuantityErrorMessages.QuantityShouldBeGreaterThan.Code)
                .WithMessage(ProductSizeQuantityErrorMessages.QuantityShouldBeGreaterThan.Description);

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithErrorCode(ProductSizeQuantityErrorMessages.ProductIdIsRequired.Code)
                .WithMessage(ProductSizeQuantityErrorMessages.ProductIdIsRequired.Description);

            RuleFor(x => x.SizeId)
                .NotEmpty()
                .WithErrorCode(ProductSizeQuantityErrorMessages.SizeIdIsRequired.Code)
                .WithMessage(ProductSizeQuantityErrorMessages.SizeIdIsRequired.Description);

            RuleFor(x => x.ProductId)
                .MustAsync(async (productId, cancellationToken) => await productRepository.ExistsAsync(productId, cancellationToken))
                .WithErrorCode(ProductSizeQuantityErrorMessages.ProductNotExists.Code)
                .WithMessage(ProductSizeQuantityErrorMessages.ProductNotExists.Description);


            RuleFor(x => x.SizeId)
                .MustAsync(async (sizeId, cancellationToken) => await sizeRepository.ExistsAsync(sizeId, cancellationToken))
                .WithErrorCode(ProductSizeQuantityErrorMessages.SizeNotExists.Code)
                .WithMessage(ProductSizeQuantityErrorMessages.SizeNotExists.Description);

            RuleFor(x => x)
                .MustAsync(async (command, cancellationToken) => !await productSizeQuantityRepository.UniqueProductBySizeAsync(command.ProductId, command.SizeId, cancellationToken))
                .WithErrorCode(ProductSizeQuantityErrorMessages.NotUnique.Code)
                .WithMessage(ProductSizeQuantityErrorMessages.NotUnique.Description);
        }
    }
}
