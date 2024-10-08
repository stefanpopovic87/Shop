using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;

namespace Shop.Application.ProductSizeQuantites.Delete
{
    internal sealed class DeleteProductSizeQuantityCommandHandler : ICommandHandler<DeleteProductSizeQuantityCommand, Result<string>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public DeleteProductSizeQuantityCommandHandler(IProductSizeQuantityRepository productSizeQuantityRepository, IProductUnitOfWork unitOfWork)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteProductSizeQuantityCommand request, CancellationToken cancellationToken)
        {
            var productSizeQuantity = await _productSizeQuantityRepository.GetByProductidAndSizeIdAsync(
                request.productId, 
                request.sizeId, 
                cancellationToken);

            if (productSizeQuantity is null)
            {
                return Result<string>.Failure(ProductSizeQuantityErrorMessages.NotFound);
            }

            _productSizeQuantityRepository.Delete(productSizeQuantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(ProductSizeQuantityErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
