using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.ProductSize.List
{
    public record GetByIdProductSizeQuery(int productId) : IRequest<Result<List<ProductSizeDto>>>;
}
