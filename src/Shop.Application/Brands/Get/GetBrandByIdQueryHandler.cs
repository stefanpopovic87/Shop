using MediatR;
using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Brands.Get
{
    internal sealed class GetBrandByIdQueryHandler : IQueryHandler<GetBrandByIdQuery, Result<CodeBookDto>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Result<CodeBookDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id, cancellationToken);

            if (brand == null) 
            {
                return Result<CodeBookDto>.Failure(BrandErrorMessages.NotFound);
            }

            var brandDto = new CodeBookDto(
                brand.Id,
                brand.Name
            );

            return Result<CodeBookDto>.Success(brandDto);
        }
    }
}
