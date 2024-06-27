using MediatR;
using Shop.Common;

namespace Shop.Application.Product.Delete
{
    public record DeleteProductCommand(int Id) : IRequest<Result<string>>;
}
