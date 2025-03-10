﻿using FluentValidation;
using TechLibrary.Communication.Request;

namespace TechLibray.Api.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(request => request.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(request => request.Email).EmailAddress().WithMessage("Email is not validt");
        RuleFor(request => request.Password).NotEmpty().WithMessage("Password is required");
        When(resquest => string.IsNullOrEmpty(resquest.Password) == false, () =>
        {
            RuleFor(request => request.Password).MinimumLength(6)
            .WithMessage("Password must be at least 6 characters");
        });
    }
}
