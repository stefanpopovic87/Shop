﻿using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Brand.Delete
{
    internal sealed class DeleteBrandCommandHandler : ICommandHandler<DeleteBrandCommand, Result<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
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

            brand.Delete();

            _brandRepository.Update(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(BrandErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
