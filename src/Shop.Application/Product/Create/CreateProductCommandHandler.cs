using MediatR;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Product.Create
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<int>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new ProductEntities.Product(request.Name, request.Description, request.Price, request.Code, request.BrandId, request.SubcategoryId, request.GenderId);

            _productRepository.Add(product);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(ProductErrorMessages.Creation);
            }

            return Result<int>.Success(product.Id);
        }
    }
}
