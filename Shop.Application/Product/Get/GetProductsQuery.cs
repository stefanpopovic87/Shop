using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Product.Get
{
    public record GetProductsQuery() : IRequest<Result<List<ProductDto>>>;
}
