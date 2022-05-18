using BWords.Common.Models.RequestModel;
using FluentValidation;

namespace BWords.Api.Application.Features.Commands.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.EmailAdress)
                .NotNull()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
                .WithMessage("{PropertyName} not valid");
            RuleFor(x => x.Password)
                .NotNull()
                .MinimumLength(6)
                .WithMessage("{PropertyName} should at least be {MinLenght} character");

        }
    }
}
