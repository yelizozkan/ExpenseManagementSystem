﻿using FluentValidation;


namespace ExpenseManagementSystem.Application.Features.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Model.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Model.Password)
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
