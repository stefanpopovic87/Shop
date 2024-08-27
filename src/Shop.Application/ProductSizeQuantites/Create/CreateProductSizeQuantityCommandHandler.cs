using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities.Products;

namespace Shop.Application.ProductSizeQuantites.Create
{
    internal class CreateProductSizeQuantityCommandHandler : ICommandHandler<CreateProductSizeQuantityCommand, Result<(int ProductId, int SizeId)>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProductSizeQuantityCommand> _validator;

        public CreateProductSizeQuantityCommandHandler(
            IProductSizeQuantityRepository productSizeQuantityRepository,
            IProductUnitOfWork unitOfWork,
            IValidator<CreateProductSizeQuantityCommand> validator)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<(int ProductId, int SizeId)>> Handle(CreateProductSizeQuantityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<(int ProductId, int SizeId)>(validationResult);
            }

            var productSizeQuantity = ProductSizeQuantity.Create(request.ProductId, request.SizeId, request.QuantityInStock);

            _productSizeQuantityRepository.Add(productSizeQuantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<(int ProductId, int SizeId)>.Failure(ProductSizeQuantityErrorMessages.Creation);
            }

            return Result<(int ProductId, int SizeId)>.Success((productSizeQuantity.ProductId, productSizeQuantity.SizeId));
        }
    }
}