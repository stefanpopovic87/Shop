using MediatR;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.ProductSize.Get
{
    public record GetProductSizeByIdQuery(int ProductId, int SizeId) : IRequest<Result<ProductSizeDto>>;
}
