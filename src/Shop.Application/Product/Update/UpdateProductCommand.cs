using MediatR;
using Shop.Common;

namespace Shop.Application.Product.Update
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        string Code,
        decimal Price,
        int BrandId,
        int SubcategoryId, 
        int GenderId) : IRequest<Result<string>>;
}
