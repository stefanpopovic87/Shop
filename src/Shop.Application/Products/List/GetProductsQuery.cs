using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Products.List
{
    public record GetProductsQuery() : IRequest<Result<List<ProductDto>>>;
}
