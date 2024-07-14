using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Brand.Update
{
    internal sealed class UpdateBrandCommandHandler : ICommandHandler<UpdateBrandCommand, Result<string>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<UpdateBrandCommand> _validator;


        public UpdateBrandCommandHandler(
            IBrandRepository brandRepository, 
            IUnitOfWork unitOfWork, 
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
