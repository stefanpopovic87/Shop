using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;

namespace Shop.Application.Brands.Delete
{
    internal sealed class DeleteBrandCommandHandler : ICommandHandler<DeleteBrandCommand, Result<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IProductUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id,cancellationToken);

            if ( brand is null) 
            {
                return Result<string>.Failure(BrandErrorMessages.NotFound);
            }

            _brandRepository.Delete(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(BrandErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
