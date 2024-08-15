using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;


namespace Shop.Application.Subcategories.Delete
{
    internal sealed class DeleteSubcategoryCommandHandler : ICommandHandler<DeleteSubcategoryCommand, Result<string>>
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubcategoryCommandHandler(ISubcategoryRepository subcategoryRepository, IUnitOfWork unitOfWork)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var subcategory = await _subcategoryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (subcategory == null)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.NotFound);
            }

            subcategory.Delete();

            _subcategoryRepository.Update(subcategory);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(SubcategoryErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
