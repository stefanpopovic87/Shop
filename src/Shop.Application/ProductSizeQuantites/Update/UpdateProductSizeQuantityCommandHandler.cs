using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.ProductSizeQuantites.Update
{
    internal sealed class UpdateProductSizeQuantityCommandHandler : ICommandHandler<UpdateProductSizeQuantityCommand, Result<string>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateProductSizeQuantityCommand> _validator;

        public UpdateProductSizeQuantityCommandHandler(
            IProductSizeQuantityRepository productSizeQuantityRepository,
            IProductUnitOfWork unitOfWork,
            IValidator<UpdateProductSizeQuantityCommand> validator)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateProductSizeQuantityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var productSizeQuantity = await _productSizeQuantityRepository.GetByProductidAndSizeIdAsync(
                request.ProductId, 
                request.SizeId, 
                cancellationToken);

            if (productSizeQuantity is null)
            {
                return Result<string>.Failure(ProductSizeQuantityErrorMessages.NotFound);
            }

            productSizeQuantity.Update(request.SizeId, request.QuantityInStock);

            _productSizeQuantityRepository.Update(productSizeQuantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(ProductSizeQuantityErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
