using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Genders.Update
{
    internal sealed class ActivateGenderCommandHandler : ICommandHandler<ActivateGenderCommand, Result<string>>
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActivateGenderCommandHandler(IGenderRepository genderRepository, IUnitOfWork unitOfWork)
        {
            _genderRepository = genderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(ActivateGenderCommand request, CancellationToken cancellationToken)
        {
            var gender = await _genderRepository.GetByIdAsync(request.Id, cancellationToken);

            if (gender is null)
            {
                return Result<string>.Failure(GenderErrorMessages.NotFound);
            }

            if (!gender.Deleted)
            {
                return Result<string>.Failure(GenderErrorMessages.AlreadyActive);
            }

            gender.Activate();

            _genderRepository.Update(gender);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(GenderErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
