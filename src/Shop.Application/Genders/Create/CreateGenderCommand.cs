using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Genders.Create
{
    public sealed record CreateGenderCommand(string Name) : ICommand<Result<int>>;
}
