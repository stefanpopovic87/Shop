﻿using FluentValidation;
using Shop.Application.Brands.Update;
using Shop.Application.Interfaces;

namespace Shop.Application.OrderStatuses.Update
{
    public sealed class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public UpdateOrderStatusCommandValidator(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode(OrderStatusErrorMessages.NameIsRequired.Code)
                .WithMessage(OrderStatusErrorMessages.NameIsRequired.Description);

            RuleFor(x => x.Name)
                .MaximumLength(OrderStatusErrorMessages.MaxNameLength)
                .WithErrorCode(OrderStatusErrorMessages.NameTooLong.Code)
                .WithMessage(OrderStatusErrorMessages.NameTooLong.Description);

            RuleFor(x => x.Name)
               .MustAsync(async (name, cancellationToken) => !await _orderStatusRepository.UniqueNameAsync(name, cancellationToken))
               .WithErrorCode(OrderStatusErrorMessages.NameNotUnique.Code)
               .WithMessage(OrderStatusErrorMessages.NameNotUnique.Description);
        }
    }
}
