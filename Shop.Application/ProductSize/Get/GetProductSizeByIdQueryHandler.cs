using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.ProductSize.Get
{
    internal sealed class GetProductSizeByIdQueryHandler : IRequestHandler<GetProductSizeByIdQuery, Result<ProductSizeDto>>
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public GetProductSizeByIdQueryHandler(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }

        public async Task<Result<ProductSizeDto>> Handle(GetProductSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var productSize = await _productSizeRepository.GetByProductIdAndSizeIdAsync(request.ProductId, request.SizeId);
            if (productSize is null)
            {
                return Result<ProductSizeDto>.Failure(ProductSizeErrorMessage.ProductSizeNotFound);

            }

            var productSizeDto = new ProductSizeDto(
               productSize.ProductId,
               productSize.Product.Name,
               productSize.Product.Description,
               productSize.Product.Price,
               productSize.Product.PictureUrl,
               productSize.Size.Name,
               productSize.Size.Id,
               productSize.QuantityInStock
            );

            return Result<ProductSizeDto>.Success(productSizeDto);
        }
    }
}
