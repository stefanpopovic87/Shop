using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Genders.Update
{
    public sealed record UpdateGenderCommand(int Id, string Name) : ICommand<Result<string>>;
}
