using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Categories.Delete
{
    internal sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Result<string>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IProductUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (category is null)
            {
                return Result<string>.Failure(CategoryErrorMessages.NotFound);
            }

            _categoryRepository.Delete(category);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(CategoryErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
