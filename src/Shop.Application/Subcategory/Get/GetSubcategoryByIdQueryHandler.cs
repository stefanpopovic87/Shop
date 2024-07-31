using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Subcategory.Get
{
    internal sealed class GetSubcategoryByIdQueryHandler : IQueryHandler<GetSubcategoryByIdQuery, Result<CodeBookDto>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;

        public GetSubcategoryByIdQueryHandler(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public async Task<Result<CodeBookDto>> Handle(GetSubcategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (subcategory == null)
            {
                return Result<CodeBookDto>.Failure(SubcategoryErrorMessages.NotFound);
            }

            var subcategoryDto = new CodeBookDto(
                subcategory.Id,
                subcategory.Name
            );

            return Result<CodeBookDto>.Success(subcategoryDto);
        }
    }
}
