using MediatR;
using Shop.Application.Dtos;
using Shop.Application.Product.Delete;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSize.Delete
{
    internal sealed class DeleteProductSizeCommandHandler : IRequestHandler<DeleteProductSizeCommand, Result<string>>
    {
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductSizeCommandHandler(IProductSizeRepository repository, IUnitOfWork unitOfWork)
        {
            _productSizeRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteProductSizeCommand request, CancellationToken cancellationToken)
        {
            var productSize = await _productSizeRepository.GetByProductIdAndSizeIdAsync(request.ProductId, request.SizeId,cancellationToken);

            if (productSize is null)
            {
                return Result<string>.Failure(ProductSizeErrorMessages.ProductSizeNotFound);
            }

            productSize.Delete();

            _productSizeRepository.Update(productSize);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(string.Empty);
        }
    }
}
