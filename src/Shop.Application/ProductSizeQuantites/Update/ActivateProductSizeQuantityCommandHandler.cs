using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.ProductSizeQuantites.Update
{
    internal sealed class ActivateProductSizeQuantityCommandHandler : ICommandHandler<ActivateProductSizeQuantityCommand, Result<string>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateProductSizeQuantityCommandHandler(IProductSizeQuantityRepository productSizeQuantityRepository, IUnitOfWork unitOfWork)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(ActivateProductSizeQuantityCommand request, CancellationToken cancellationToken)
        {
            var productSizeQuantity = await _productSizeQuantityRepository.GetByProductidAndSizeIdAsync(request.ProductId, request.SizeId, cancellationToken);

            if (productSizeQuantity is null)
            {
                return Result<string>.Failure(ProductSizeQuantityErrorMessages.NotFound);
            }

            //TODO - change logic
            //if (!productSizeQuantity.Deleted)
            //{
            //    return Result<string>.Failure(ProductSizeQuantityErrorMessages.AlreadyActive);
            //}

            //productSizeQuantity.Activate();

            _productSizeQuantityRepository.Update(productSizeQuantity);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(ProductSizeQuantityErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
