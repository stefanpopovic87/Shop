using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Size.List
{
    internal sealed class GetSizesByCategoryIdQueryHandler : IQueryHandler<GetSizesByCategoryIdQuery, Result<List<CodeBookDto>>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetSizesByCategoryIdQueryHandler(
            ISizeRepository sizeRepository, 
            ICategoryRepository categoryRepository)
        {
            _sizeRepository = sizeRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetSizesByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var categoryExist = await _categoryRepository.ExistsAsync(request.categoryId, cancellationToken);

            if (!categoryExist)
            {
                return Result<List<CodeBookDto>>.Failure(SizeErrorMessages.CategoryNotExists);

            }
            var sizes = await _sizeRepository.GetAllByCategoryIdAsync(request.categoryId, cancellationToken);

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
