﻿using Shop.Application.Abstractions;
using Shop.Application.Dtos.Base;
using Shop.Common;
using Shop.Application.Interfaces;

namespace Shop.Application.Genders.List
{
    internal sealed class GetGendersQueryHandler : IQueryHandler<GetGendersQuery, Result<List<CodeBookDto>>>
    {
        private readonly IGenderRepository _genderRepository;

        public GetGendersQueryHandler(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<Result<List<CodeBookDto>>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            var genders = await _genderRepository.GetAllAsync(cancellationToken);

            if (genders is null || genders.Count == 0)
            {
                return Result<List<CodeBookDto>>.Failure(GenderErrorMessages.GendersNotFound);
            }

            var gendersDto = genders.Select(x => new CodeBookDto
            (
                x.Id,
                x.Name
            )).ToList();

            return Result<List<CodeBookDto>>.Success(gendersDto);
        }
    }
}
