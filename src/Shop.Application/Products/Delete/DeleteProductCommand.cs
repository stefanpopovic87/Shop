using MediatR;
using Shop.Common;

namespace Shop.Application.Products.Delete
{
    public record DeleteProductCommand(int Id) : IRequest<Result<string>>;
}
