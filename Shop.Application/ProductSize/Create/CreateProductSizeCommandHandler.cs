using MediatR;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSize.Create
{
    internal sealed class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, Result<int>>
    {
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductSizeCommandHandler(IProductSizeRepository productSizeRepository, IUnitOfWork unitOfWork)
        {
            _productSizeRepository = productSizeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
        {
            var productSizeFromDb = await _productSizeRepository.GetByProductIdAndSizeIdAsync(request.ProductId, request.SizeId);

            if (productSizeFromDb is not null)
            {
                return Result<int>.Failure(ProductSizeErrorMessage.AlreadyExistError);
            }

            var productSize = new Domain.Entities.Product.ProductSize(request.ProductId, request.SizeId, request.QuantityInStock);

            _productSizeRepository.Add(productSize);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(ProductSizeErrorMessage.CreationError);
            }

            return Result<int>.Success(productSize.ProductId);
        }
    }
}
