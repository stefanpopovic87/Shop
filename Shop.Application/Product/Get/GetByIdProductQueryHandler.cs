using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Product.Get
{
    internal sealed class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductDto>> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product is null)
            {
                return Result<ProductDto>.Failure(ProductErrorMessages.ProductNotFound(request.Id));

            }

            var productDto = new ProductDto(
               product.Id,
               product.Name,
               product.Description,
               product.Price,
               product.PictureUrl
            );

            return Result<ProductDto>.Success(productDto);

        }
    }
}
