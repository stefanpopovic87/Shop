using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSize.List
{
    internal sealed class GetByIdProductSizeQueryHandler : IRequestHandler<GetByIdProductSizeQuery, Result<List<ProductSizeDto>>>
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public GetByIdProductSizeQueryHandler(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

        public async Task<Result<List<ProductSizeDto>>> Handle(GetByIdProductSizeQuery request, CancellationToken cancellationToken)
        {
            var productSizes = await _productSizeRepository.GetByProductIdAsync(request.productId, cancellationToken);

            if (productSizes is null || productSizes.Count == 0)
            {
                return Result<List<ProductSizeDto>>.Failure(ProductSizeErrorMessages.ProductsNotFound(request.productId));

            }

            var productSizesDto = productSizes
                .Select(x => new ProductSizeDto(
                    x.ProductId,
                    x.Product?.Name ?? string.Empty,
                    x.Product?.Description ?? string.Empty,
                    x.Product?.Price ?? 0,
                    x.Product?.PictureUrl,
                    x.Size.Name,
                    x.Size.Id,
                    x.QuantityInStock
                )).ToList();

            return Result<List<ProductSizeDto>>.Success(productSizesDto);

        }
    }
}
