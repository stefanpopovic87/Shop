using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Category.Get
{
    internal sealed class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, Result<CodeBookDto>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<CodeBookDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category == null)
            {
                return Result<CodeBookDto>.Failure(CategoryErrorMessages.NotFound);
            }

            var categoryDto = new CodeBookDto(
                category.Id,
                category.Name
            );

            return Result<CodeBookDto>.Success(categoryDto);
        }
    }
}
