using MediatR;

namespace Shop.Application.Product.Delete
{
    public record DeleteProductCommand(int id) : IRequest;
}
