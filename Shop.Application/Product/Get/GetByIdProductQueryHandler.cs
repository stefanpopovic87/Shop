using MediatR;
using Shop.Application.Dtos;
using Shop.Domain.Entities.Product.Exceptions;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Get
{
    internal sealed class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product is null)
            {
                throw new ProductNotFoundException(request.Id);
            }

            return new ProductDto(
               product.Id,
               product.Name,
               product.Description,
               product.Price,
               product.PictureUrl
            );
        }
    }
}
