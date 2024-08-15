using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.Genders.Update
{
    public sealed record ActivateGenderCommand(int Id) : ICommand<Result<string>>;
}
