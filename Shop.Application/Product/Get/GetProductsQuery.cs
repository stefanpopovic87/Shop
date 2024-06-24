using MediatR;
using Shop.Application.Dtos;

namespace Shop.Application.Product.Get
{
    public record GetProductsQuery() : IRequest<List<ProductDto>>;
}
