using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Subcategories.List
{
    internal class GetSubcategoriesByCategoryIdQueryHandler : IQueryHandler<GetSubcategoriesByCategoryIdQuery, Result<List<CodeBookDto>>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GetSubcategoriesByCategoryIdQueryHandler(ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetSubcategoriesByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var categoryExist = await _categoryRepository.ExistsAsync(request.categoryId, cancellationToken);

            if (!categoryExist)
            {
                return Result<List<CodeBookDto>>.Failure(SubcategoryErrorMessages.CategoryNotExist);

            }

            var subcategories = await _subcategoryRepository.GetAllByCategoryIdAsync(request.categoryId, cancellationToken);

            if (subcategories == null || subcategories.Count == 0)
            {
                return Result<List<CodeBookDto>>.Failure(SubcategoryErrorMessages.SubcategoriesNotFound);
            }

            var subcategoriesDtos = subcategories.Select(x => new CodeBookDto(
                x.Id,
                x.Name
            )).ToList();

            return Result<List<CodeBookDto>>.Success(subcategoriesDtos);
        }
    }
}
