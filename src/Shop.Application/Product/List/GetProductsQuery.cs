using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Product.List
{
    public record GetProductsQuery() : IRequest<Result<List<ProductDto>>>;
}
