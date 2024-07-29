using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Get
{
    internal sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdIncludeSizeQuantitiesAsync(request.Id, cancellationToken);
            if (product is null)
            {
                return Result<ProductDto>.Failure(ProductErrorMessages.NotFound);

            }

            var productDto = new ProductDto(
               product.Id,
               product.Name,
               product.Description,
               product.Price,
               product.Code,
               product.BrandId,
               product.SubcategoryId,
               product.GenderId,
               product.SizeQuantities
                .Select(x => new SizeQuantityDto(x.SizeId, x.QuantityInStock))
                .ToList()
            );

            return Result<ProductDto>.Success(productDto);

        }
    }
}
