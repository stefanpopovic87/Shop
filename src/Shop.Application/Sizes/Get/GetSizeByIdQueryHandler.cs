using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Sizes.Get
{
    internal sealed class GetSizeByIdQueryHandler : IQueryHandler<GetSizeByIdQuery, Result<CodeBookDto>>
    {
        private readonly ISizeRepository _sizeRepository;

        public GetSizeByIdQueryHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<Result<CodeBookDto>> Handle(GetSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var size = await _sizeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (size == null)
            {
                return Result<CodeBookDto>.Failure(SizeErrorMessages.NotFound);
            }

            var sizeDto = new CodeBookDto(
                size.Id,
                size.Name
            );

            return Result<CodeBookDto>.Success(sizeDto);
        }
    }
}
