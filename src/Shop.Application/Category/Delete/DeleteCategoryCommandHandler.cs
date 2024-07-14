using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Category.Delete
{
    internal sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, Result<string>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
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

            category.Delete();

            _categoryRepository.Update(category);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(CategoryErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
