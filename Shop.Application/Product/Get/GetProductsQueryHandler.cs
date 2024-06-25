using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Get
{
    internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<List<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            if (products is null)
            {
                return Result<List<ProductDto>>.Failure(ProductErrorMessages.ProductsNotFound);
            }

            var productDtos = products.Select(x => new ProductDto
               (
                  x.Id,
                  x.Name,
                  x.Description,
                  x.Price,
                  x.PictureUrl
               )).ToList();

            return Result<List<ProductDto>>.Success(productDtos);
        }
    }
}
