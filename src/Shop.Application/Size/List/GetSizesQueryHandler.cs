using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Size.List
{
    internal sealed class GetSizesQueryHandler : IQueryHandler<GetSizesQuery, Result<List<CodeBookDto>>>
    {
        private readonly ISizeRepository _sizeRepository;

        public GetSizesQueryHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetSizesQuery request, CancellationToken cancellationToken)
        {
            var sizes = await _sizeRepository.GetAllAsync(cancellationToken);

            if (sizes is null || sizes.Count == 0)
            {
                return Result<List<CodeBookDto>>.Failure(SizeErrorMessages.SizesNotFound);
            }

            var sizesDto = sizes.Select(x => new CodeBookDto
            (
                x.Id,
                x.Name
            )).ToList();

            return Result<List<CodeBookDto>>.Success(sizesDto);
        }
    }
}
