using Shop.Common;
using Shop.Domain.Interfaces;

namespace Shop.Application.Brand.Create
{
    public class CreateBrandCommandValidator
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandCommandValidator(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Result<CreateBrandCommand>> ValidateAsync(CreateBrandCommand command, CancellationToken cancellationToken)
        {

            //if (string.IsNullOrWhiteSpace(command.Name))
            //{
            //    validationErrors.Add(new ValidationError(nameof(command.Name), "Brand name is required."));
            //}

            //if (await _brandRepository.IsNameUnique(command.Name, cancellationToken) == false)
            //{
            //    validationErrors.Add(new ValidationError(nameof(command.Name), "Brand name must be unique."));
            //}

            //if (validationErrors.Any())
            //{
            //    return Result<CreateBrandCommand>.ValidationFailure(validationErrors);
            //}

            return Result<CreateBrandCommand>.Success(command);
        }
    }
}
