using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Brand.List
{
    internal sealed class GetBrandsQueryHandler : IQueryHandler<GetBrandsQuery, Result<List<CodeBookDto>>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepository.GetAllAsync(cancellationToken);

            if (brands is null || brands.Count == 0)
            {
                return Result<List<CodeBookDto>>.Failure(BrandErrorMessages.BrandsNotFound);
            }

            var brandsDto = brands.Select(x => new CodeBookDto
            (
                x.Id,
                x.Name
            )).ToList();

            return Result<List<CodeBookDto>>.Success(brandsDto);
        }
    }
}
