using FluentValidation;
using Shop.Application.Abstractions;
using Shop.Application.Helpers;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;

namespace Shop.Application.Brands.Create
{
    internal sealed class CreateBrandCommandHandler : ICommandHandler<CreateBrandCommand, Result<int>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateBrandCommand> _validator;

        public CreateBrandCommandHandler(
            IBrandRepository brandRepository,
            IUnitOfWork unitOfWork,
            IValidator<CreateBrandCommand> validator)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return ValidationErrorHelper.CreateValidationErrorResult<int>(validationResult);
            }

            var brand = new Brand(request.Name);

            _brandRepository.Add(brand);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<int>.Failure(BrandErrorMessages.Creation);
            }

            return Result<int>.Success(brand.Id);
        }
    }
}
