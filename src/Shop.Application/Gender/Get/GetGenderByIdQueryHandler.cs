using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Gender.Get
{
    internal sealed class GetGenderByIdQueryHandler : IQueryHandler<GetGenderByIdQuery, Result<CodeBookDto>>
    {
        private readonly IGenderRepository _genderRepository;

        public GetGenderByIdQueryHandler(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<Result<CodeBookDto>> Handle(GetGenderByIdQuery request, CancellationToken cancellationToken)
        {
            var gender = await _genderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (gender == null)
            {
                return Result<CodeBookDto>.Failure(GenderErrorMessages.NotFound);
            }

            var genderDto = new CodeBookDto(
                gender.Id,
                gender.Name
            );

            return Result<CodeBookDto>.Success(genderDto);
        }
    }
}
