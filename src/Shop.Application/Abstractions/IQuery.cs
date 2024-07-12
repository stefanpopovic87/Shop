using MediatR;

namespace Shop.Application.Abstractions;
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
