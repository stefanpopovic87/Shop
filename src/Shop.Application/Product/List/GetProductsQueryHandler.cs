using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.List
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
            var products = await _productRepository.GetAllIdIncludeSizeQuantitiesAsync(cancellationToken);

            if (products is null || products.Count == 0)
            {
                return Result<List<ProductDto>>.Failure(ProductErrorMessages.NotFound);
            }

            var productsDto = products.Select(x => new ProductDto
               (
                  x.Id,
                  x.Name,
                  x.Description,
                  x.Price,
                  x.Code,
                  x.BrandId,
                  x.SubcategoryId,
                  x.GenderId,
                  x.SizeQuantities
                  .Select(x => new SizeQuantityDto(x.SizeId, x.QuantityInStock))
                  .ToList()
               )).ToList();

            return Result<List<ProductDto>>.Success(productsDto);
        }
    }
}
