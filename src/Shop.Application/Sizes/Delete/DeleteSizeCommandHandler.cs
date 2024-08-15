using Shop.Application.Abstractions;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Sizes.Delete
{
    internal sealed class DeleteSizeCommandHandler : ICommandHandler<DeleteSizeCommand, Result<string>>
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSizeCommandHandler(ISizeRepository sizeRepository, IUnitOfWork unitOfWork)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            var size = await _sizeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (size is null)
            {
                return Result<string>.Failure(SizeErrorMessages.NotFound);
            }

            size.Delete();

            _sizeRepository.Update(size);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) == 0)
            {
                return Result<string>.Failure(SizeErrorMessages.Deletion);
            }

            return Result<string>.Success(string.Empty);
        }
    }
}
