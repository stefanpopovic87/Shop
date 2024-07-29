using Shop.Application.Abstractions;
using Shop.Application.Dtos;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSizeQuantity.Get
{
    internal sealed class GetProductSizeQuantityByIdQueryHandler : IQueryHandler<GetProductSizeQuantityByIdQuery, Result<ProductSizeQuantityDto>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;

        public GetProductSizeQuantityByIdQueryHandler(IProductSizeQuantityRepository productSizeQuantityRepository)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
        }

        public async Task<Result<ProductSizeQuantityDto>> Handle(GetProductSizeQuantityByIdQuery request, CancellationToken cancellationToken)
        {
            var productSizeQuantity = await _productSizeQuantityRepository.GetByProductidAndSizeIdAsync(
                request.ProductId, 
                request.SizeId, 
                cancellationToken);

            if (productSizeQuantity is null)
            {
                return Result<ProductSizeQuantityDto>.Failure(ProductSizeQuantityErrorMessages.NotFound);
            }

            var productSizeQuantityDto = new ProductSizeQuantityDto(
                productSizeQuantity.ProductId, 
                productSizeQuantity.SizeId,
                productSizeQuantity.QuantityInStock
            );

            return Result<ProductSizeQuantityDto>.Success(productSizeQuantityDto);
        }
    }
}
