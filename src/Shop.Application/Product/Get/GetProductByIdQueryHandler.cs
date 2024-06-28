using MediatR;
using Shop.Application.Dtos;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
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
            var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
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
