using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Brand.Create
{
    internal sealed class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, Result<int>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CreateBrandCommandHandler(
            IBrandRepository brandRepository, 
            IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new ProductEntities.Brand(request.Name);

            _brandRepository.Add(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(BrandErrorMessages.Creation);
            }

            return Result<int>.Success(brand.Id);
        }
    }
}
