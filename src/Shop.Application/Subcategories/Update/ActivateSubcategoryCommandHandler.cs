using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Subcategories.Update
{
    internal sealed class ActivateSubcategoryCommandHandler : ICommandHandler<ActivateSubcategoryCommand, Result<string>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateSubcategoryCommandHandler(ISubcategoryRepository subcategoryRepository, IUnitOfWork unitOfWork)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(ActivateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (subcategory == null)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.NotFound);
            }

            if (!subcategory.Deleted)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.AlreadyActive);
            }

            subcategory.Activate();

            _subcategoryRepository.Update(subcategory);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
