using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;


namespace Shop.Application.Categories.Update
{
    namespace Shop.Application.Category.Update
    {
        internal sealed class ActivateCategoryCommandHandler : ICommandHandler<ActivateCategoryCommand, Result<string>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IProductUnitOfWork _unitOfWork;

            public ActivateCategoryCommandHandler(ICategoryRepository categoryRepository, IProductUnitOfWork unitOfWork)
            {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<string>> Handle(ActivateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

                if (category is null)
                {
                    return Result<string>.Failure(CategoryErrorMessages.NotFound);
                }

                //TODO - change logic
                //if (!category.Deleted)
                //{
                //    return Result<string>.Failure(CategoryErrorMessages.AlreadyActive);
                //}

                //category.Activate();

                _categoryRepository.Update(category);

                if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
                {
                    return Result<string>.Failure(CategoryErrorMessages.Activation);
                }

                return Result<string>.Success(string.Empty);
            }
        }
    }
}
