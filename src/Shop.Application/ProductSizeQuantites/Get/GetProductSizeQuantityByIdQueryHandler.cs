using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.ProductSizeQuantites.Get
{
    internal sealed class GetProductSizeQuantityByIdQueryHandler : IQueryHandler<GetProductSizeQuantityByIdQuery, Result<GetProductSizeQuantityByIdResponse>>
    {
        private readonly IProductSizeQuantityRepository _productSizeQuantityRepository;

        public GetProductSizeQuantityByIdQueryHandler(IProductSizeQuantityRepository productSizeQuantityRepository)
        {
            _productSizeQuantityRepository = productSizeQuantityRepository;
        }

        public async Task<Result<GetProductSizeQuantityByIdResponse>> Handle(GetProductSizeQuantityByIdQuery request, CancellationToken cancellationToken)
        {
            var productSizeQuantity = await _productSizeQuantityRepository.GetByProductidAndSizeIdAsync(
                request.ProductId, 
                request.SizeId, 
                cancellationToken);

            if (productSizeQuantity is null)
            {
                return Result<GetProductSizeQuantityByIdResponse>.Failure(ProductSizeQuantityErrorMessages.NotFound);
            }

            var productSizeQuantityDto = new GetProductSizeQuantityByIdResponse(
                productSizeQuantity.ProductId, 
                productSizeQuantity.SizeId,
                productSizeQuantity.QuantityInStock
            );

            return Result<GetProductSizeQuantityByIdResponse>.Success(productSizeQuantityDto);
        }
    }
}
