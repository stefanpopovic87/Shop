using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Subcategory.List
{
    internal sealed class GetSubcategoriesQueryHandler : IQueryHandler<GetSubcategoriesQuery, Result<List<CodeBookDto>>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public GetSubcategoriesQueryHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetSubcategoriesQuery request, CancellationToken cancellationToken)
        {
            var subcategories = await _subcategoryRepository.GetAllAsync(cancellationToken);

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
