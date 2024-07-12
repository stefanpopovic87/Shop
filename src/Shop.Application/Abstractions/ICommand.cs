using MediatR;

namespace Shop.Application.Abstractions;
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
