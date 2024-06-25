using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;


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
            var product = Shop.Domain.Entities.Product.Product.Create(
                request.Name, 
                request.Description,
                request.Price, 
                request.PictureUrl);

            _productRepository.Add(product);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(ProductErrorMessages.CreationError);
            }

            return Result<int>.Success(product.Id);
        }
    }
}
