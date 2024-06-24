using MediatR;
using Shop.Application.Dtos;
using Shop.Domain.Entities.Product.Exceptions;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Get
{
    internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            if (products is null)
            {
                throw new ProductsNotFoundException();
            }

            return products.Select( x => new ProductDto
            (
               x.Id,
               x.Name,
               x.Description,
               x.Price,
               x.PictureUrl
            )).ToList();
        }
    }
}
