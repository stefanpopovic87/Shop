using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Categories.List
{
    internal sealed class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, Result<List<CodeBookDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync(cancellationToken);

            if (categories is null || categories.Count == 0)
            {
                return Result<List<CodeBookDto>>.Failure(CategoryErrorMessages.CategoriesNotFound);
            }

            var categoriesDto = categories.Select(x => new CodeBookDto
            (
                x.Id,
                x.Name
            )).ToList();

            return Result<List<CodeBookDto>>.Success(categoriesDto);
        }
    }
}
