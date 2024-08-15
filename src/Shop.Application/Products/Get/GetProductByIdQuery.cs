using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Products.Get
{
    public record GetProductByIdQuery(int Id) : IRequest<Result<ProductDto>>;
}
