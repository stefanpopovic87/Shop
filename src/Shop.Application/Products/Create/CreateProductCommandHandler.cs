using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Application.Builders;

namespace Shop.Application.Products.Create
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

            var product = ProductBuilder.StartBuildingProduct()
               .WithDetails(p => p
                   .Named(request.Name)
                   .Described(request.Description)
                   .PriceOf(request.Price)
                   .WithCode(request.Code))
               .AssignedBrand(request.BrandId)
               .BelongingToSubcategory(request.SubcategoryId)
               .ForGender(request.GenderId)
               .WithSizeAndQuantities(request.ProductSizeQuantities.Select(q => (q.SizeId, q.Quantity)))
               .Build();

            _productRepository.Add(product);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(ProductErrorMessages.Creation);
            }

            return Result<int>.Success(product.Id);
        }
    }
}
