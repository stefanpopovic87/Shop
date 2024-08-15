using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities.Products;
using Shop.Application.Builders;

namespace Shop.Application.Products.Update
{
    internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Result<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductCommand> _validator;

        public UpdateProductCommandHandler(
            IProductRepository productRepository, 
            IUnitOfWork unitOfWork, 
            IValidator<UpdateProductCommand> validator)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var product = await _productRepository.GetByIdIncludeSizeQuantitiesAsync(request.Id, cancellationToken);

            if (product is null)
            {
                return Result<string>.Failure(ProductErrorMessages.NotFound);
            }

            var productDetails = new ProductDetails(request.Name, request.Description, request.Price, request.Code);
            product.Update(productDetails, request.BrandId, request.SubcategoryId, request.GenderId);

            _productRepository.Update(product);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(ProductErrorMessages.Update);
            }

            return Result<string>.Success(string.Empty);

        }
    }
}
