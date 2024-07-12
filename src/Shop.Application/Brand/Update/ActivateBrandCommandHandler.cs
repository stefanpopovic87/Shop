﻿using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Domain.Entities.ErrorMessages;
using Shop.Domain.Interfaces;

namespace Shop.Application.Brand.Update
{
    internal sealed class ActivateBrandCommandHandler : ICommandHandler<ActivateBrandCommand, Result<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
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

            brand.Activate();

            _brandRepository.Update(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(BrandErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
