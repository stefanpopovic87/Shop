using MediatR;
using Shop.Domain.Entities.Product.Exceptions;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Delete
{
    internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _productRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.id);

            if (product is null)
            {
                throw new ProductNotFoundException(request.id);
            }

            product.Delete();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
