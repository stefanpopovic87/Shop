using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;

namespace Shop.Application.Sizes.Update
{
    internal sealed class ActivateSizeCommandHandler : ICommandHandler<ActivateSizeCommand, Result<string>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IProductUnitOfWork _unitOfWork;

        public ActivateSizeCommandHandler(ISizeRepository sizeRepository, IProductUnitOfWork unitOfWork)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(ActivateSizeCommand request, CancellationToken cancellationToken)
        {
            var size = await _sizeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (size is null)
            {
                return Result<string>.Failure(SizeErrorMessages.NotFound);
            }

            //TODO - change logic
            //if (!size.Deleted)
            //{
            //    return Result<string>.Failure(SizeErrorMessages.AlreadyActive);
            //}

            //size.Activate();

            _sizeRepository.Update(size);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(SizeErrorMessages.Activation);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
