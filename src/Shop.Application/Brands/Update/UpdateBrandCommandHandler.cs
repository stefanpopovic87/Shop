using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;

namespace Shop.Application.Brands.Update
{
    internal sealed class UpdateBrandCommandHandler : ICommandHandler<UpdateBrandCommand, Result<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateBrandCommand> _validator;


        public UpdateBrandCommandHandler(
            IBrandRepository brandRepository, 
            IProductUnitOfWork unitOfWork, 
            IValidator<UpdateBrandCommand> validator)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<string>> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<string>(validationResult);
            }

            var brand = await _brandRepository.GetByIdAsync(request.Id, cancellationToken);

            if (brand is null)
            {
                return Result<string>.Failure(BrandErrorMessages.NotFound);
            }

            brand.Update(request.Name);

            _brandRepository.Update(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(BrandErrorMessages.Update);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
