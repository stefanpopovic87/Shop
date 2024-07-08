using MediatR;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSize.Create
{
    internal sealed class CreateProductSizeCommandHandler : IRequestHandler<CreateProductSizeCommand, Result<(int ProductId, int SizeId)>>
    {
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductSizeCommandHandler(
            IProductSizeRepository productSizeRepository, 
            IUnitOfWork unitOfWork, 
            IProductRepository productRepository, 
            ISizeRepository sizeRepository)
        {
            _productSizeRepository = productSizeRepository;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
        }

        public async Task<Result<(int ProductId, int SizeId)>> Handle(CreateProductSizeCommand request, CancellationToken cancellationToken)
        {
            var productSizeFromDb = await _productSizeRepository.GetByProductIdAndSizeIdAsync(request.ProductId, request.SizeId, cancellationToken);

            if (productSizeFromDb is not null)
            {
                return Result<(int ProductId, int SizeId)>.Failure(ProductSizeErrorMessages.AlreadyExist);
            }

            var productExists = await _productRepository.ExistsAsync(request.ProductId, cancellationToken);

            if (!productExists) 
            {
                return Result<(int ProductId, int SizeId)>.Failure(ProductErrorMessages.NotFound);
            }

            var sizeExists = await _sizeRepository.ExistsAsync(request.SizeId, cancellationToken);

            if (!sizeExists) 
            {
                return Result<(int ProductId, int SizeId)>.Failure(SizeErrorMessages.NotFound);
            }

            var productSize = new Domain.Entities.Product.ProductSize(request.ProductId, request.SizeId, request.QuantityInStock);

            _productSizeRepository.Add(productSize);

           
            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<(int ProductId, int SizeId)>.Failure(ProductSizeErrorMessages.Creation);
            }           

            return Result<(int ProductId, int SizeId)>.Success((productSize.ProductId, productSize.SizeId));
        }
    }
}
