using MediatR;
using Shop.Domain.Entities.Product.Exceptions;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Update
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            product.Update(request.Name, request.Description, request.Price, request.PictureUrl);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
