using MediatR;
using Shop.Application.Dtos;

namespace Shop.Application.Product.Get
{
    public record GetByIdProductQuery(int Id) : IRequest<ProductDto>;
}
