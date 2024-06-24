using MediatR;
using Shop.Domain.Interfaces;


namespace Shop.Application.Product.Create
{
    internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Shop.Domain.Entities.Product.Product.Create(
                request.Name, 
                request.Description,
                request.Price, 
                request.PictureUrl);

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync();

            return product.Id;
        }
    }
}
