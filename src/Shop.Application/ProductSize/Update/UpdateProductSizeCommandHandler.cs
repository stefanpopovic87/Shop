using MediatR;
using Shop.Application.Product.Update;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSize.Update
{
    internal sealed class UpdateProductSizeCommandHandler : IRequestHandler<UpdateProductSizeCommand, Result<string>>
    {
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductSizeCommandHandler(IProductSizeRepository productSizeRepository, IUnitOfWork unitOfWork)
        {
            _productSizeRepository = productSizeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(UpdateProductSizeCommand request, CancellationToken cancellationToken)
        {
            var productSize = await _productSizeRepository.GetByProductIdAndSizeIdAsync(request.ProductId, request.SizeId);

            if (productSize is null)
            {
                return Result<string>.Failure(ProductSizeErrorMessages.ProductSizeNotFound);
            }

            productSize.UpdateQuantity(request.QuantityInStock);

            _productSizeRepository.Update(productSize);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(string.Empty);
        }
    }
}
