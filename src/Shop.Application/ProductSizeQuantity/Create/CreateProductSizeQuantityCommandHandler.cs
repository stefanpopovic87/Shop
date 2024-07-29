﻿using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Domain.Interfaces;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.ProductSizeQuantity.Create
{
    internal class CreateProductSizeQuantityCommandHandler : ICommandHandler<CreateProductSizeQuantityCommand, Result<(int ProductId, int SizeId)>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProductSizeQuantityCommand> _validator;

        public CreateProductSizeQuantityCommandHandler(
            IProductSizeQuantityRepository productSizeQuantityRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateProductSizeQuantityCommand> validator,
            IProductRepository productRepository)
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

            var productSizeQuantity = new ProductEntities.ProductSizeQuantity(request.ProductId, request.SizeId, request.QuantityInStock);

            _productSizeQuantityRepository.Add(productSizeQuantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<(int ProductId, int SizeId)>.Failure(ProductSizeQuantityErrorMessages.Creation);
            }

            return Result<(int ProductId, int SizeId)>.Success((productSizeQuantity.ProductId, productSizeQuantity.SizeId));
        }
    }
}