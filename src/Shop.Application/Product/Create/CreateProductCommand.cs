using MediatR;
using Shop.Common;

namespace Shop.Application.Product.Create
{
    public record CreateProductCommand(
        string Name, 
        string Description, 
        string Code, 
        decimal Price,
        int BrandId,
        int SubcategoryId, 
        int GenderId) : IRequest<Result<int>>;
}
