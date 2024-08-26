using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Genders.Delete
{
    internal sealed class DeleteGenderCommandHandler : ICommandHandler<DeleteGenderCommand, Result<string>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public DeleteGenderCommandHandler(IGenderRepository genderRepository, IProductUnitOfWork unitOfWork)
        {
            _genderRepository = genderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteGenderCommand request, CancellationToken cancellationToken)
        {
            var gender = await _genderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (gender is null)
            {
                return Result<string>.Failure(GenderErrorMessages.NotFound);
            }

            _genderRepository.Update(gender);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(GenderErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
