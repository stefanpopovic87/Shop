using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Gender.Create
{
    public sealed record CreateGenderCommand(string Name) : ICommand<Result<int>>;
}
