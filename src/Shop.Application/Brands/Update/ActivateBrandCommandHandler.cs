﻿using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Brands.Update
{
    internal sealed class ActivateBrandCommandHandler : ICommandHandler<ActivateBrandCommand, Result<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public ActivateBrandCommandHandler(IBrandRepository brandRepository, IProductUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(ActivateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id, cancellationToken);

            if (brand is null)
            {
                return Result<string>.Failure(BrandErrorMessages.NotFound);
            }

            //TODO - change logic
            //if (!brand.Deleted)
            //{
            //    return Result<string>.Failure(BrandErrorMessages.AlreadyActive);
            //}

            //brand.Activate();

            _brandRepository.Update(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(BrandErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
