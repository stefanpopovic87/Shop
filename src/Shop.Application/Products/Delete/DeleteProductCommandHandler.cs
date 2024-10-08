using MediatR;
using Shop.Common;
using Shop.Domain.ErrorMessages;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;

namespace Shop.Application.Products.Delete
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository repository, IProductUnitOfWork unitOfWork)
        {
            _productRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);

            if (product is null)
            {
                return Result<string>.Failure(ProductErrorMessages.NotFound);
            }

            _productRepository.Delete(product);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(string.Empty);
        }
    }
}
