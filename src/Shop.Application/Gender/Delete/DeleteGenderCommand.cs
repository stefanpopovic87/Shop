using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Gender.Delete
{
    public sealed record DeleteGenderCommand(int Id) : ICommand<Result<string>>;
}
