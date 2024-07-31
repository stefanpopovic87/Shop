using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Product.Create
{
    internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductCommandHandler(
            IProductRepository productRepository, 
            IUnitOfWork unitOfWork, 
            IValidator<CreateProductCommand> validator)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var product = new ProductEntities.Product(
                request.Name,
                request.Description,
                request.Price,
                request.Code,
                request.BrandId,
                request.SubcategoryId,
                request.GenderId
            );

            foreach (var sizeQuantity in request.ProductSizeQuantities)
            {
                product.AddSizeQuantity(sizeQuantity.SizeId, sizeQuantity.Quantity);
            }

            _productRepository.Add(product);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(ProductErrorMessages.Creation);
            }

            return Result<int>.Success(product.Id);
        }
    }
}
